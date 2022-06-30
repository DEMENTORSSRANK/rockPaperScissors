using System;
using System.Threading.Tasks;
using Sources.Model.Fists;
using Sources.Model.GameScenarios.Parameters;
using Sources.Model.Players;

namespace Sources.Model.GameScenarios
{
    public class GameScenario
    {
        private readonly BasePlayer _player;

        private readonly BasePlayer _enemy;

        private readonly FistComparator _comparator;

        private readonly GameScore _score;

        private readonly int _moveDelay;

        public bool Playing { get; private set; }

        public IReadOnlyGameScore Score => _score;

        /// <summary>
        /// True - player, False - enemy
        /// </summary>
        public event Action<bool> AnyWon;

        public event Action StartChoosing;
        
        public event Action<FistType> PlayerChosen;

        public event Action<FistType> EnemyChosen;

        public event Action<ResultType> Moved;

        public GameScenario(BasePlayer player, BasePlayer enemy, int scoreToWin = 1, int moveDelay = 500)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _comparator = new FistComparator();
            _score = new GameScore(scoreToWin);
            _moveDelay = moveDelay;
        }

        public void Start()
        {
            if (Playing)
                throw new InvalidOperationException("Game is already started");
            
            _score.Reset();
            
            ProcessAsync();
        }
        
        private async void ProcessAsync()
        {
            Playing = true;

            while (!_score.CheckIsAnyWin())
            {
                StartChoosing?.Invoke();
                
                FistType playerChoose = await _player.MakeChoiceAsync();
                
                PlayerChosen?.Invoke(playerChoose);

                FistType enemyChoose = await _enemy.MakeChoiceAsync();
                
                EnemyChosen?.Invoke(enemyChoose);

                ResultType result = _comparator.Compare(playerChoose, enemyChoose);
                
                await Task.Delay(_moveDelay);
                
                Moved?.Invoke(result);

                _score.ApplyByResultMove(result);
            }
            
            AnyWon?.Invoke(_score.PlayerWinning);
            
            Playing = false;
        }
    }
}