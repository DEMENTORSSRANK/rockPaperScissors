using Sources.Extensions;
using Sources.Input;
using Sources.Model.GameScenarios;
using Sources.Model.Players;
using Sources.View.Fists;
using Sources.View.UserInterface;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class GameVersusBotCompositeRoot : MonoBehaviour
    {
        [Header("Parameters")] 
        
        [Min(1)] [SerializeField] private int _scoreToWin = 2;

        [Min(0)] [SerializeField] private float _moveDelay = .5f;

        [Header("View")] 
        
        [SerializeField] private PlayerScreen _playerScreen;

        [SerializeField] private FistView _fistView;

        [SerializeField] private EndScreen _endScreen;

        private PlayerInput _input;

        private PlayerInputRouter _inputRouter;

        private Player _player;

        private GameScenario _scenario;

        private void Awake()
        {
            var bot = new Bot();
            
            _player = new Player();
            
            _scenario = new GameScenario(_player, bot, _scoreToWin, _moveDelay.InMilliSeconds());
            
            _input = new PlayerInput();
            
            _inputRouter = new PlayerInputRouter(_playerScreen.PlayerInputPanel, _input);
        }

        private void OnEnable()
        {
            _inputRouter.Subscribe();

            _input.Played += _player.PlayWithFist;

            _scenario.PlayerChosen += _playerScreen.OnPlayerPlayed;

            _scenario.PlayerChosen += _fistView.OnPlayerChosen;

            _scenario.EnemyChosen += _fistView.OnEnemyChosen;

            _scenario.AnyWon += _endScreen.OnAnyWon;

            _endScreen.OnRestartClicked += _scenario.Start;

            _scenario.Score.Updated += _playerScreen.OnScoreChanged;

            _scenario.StartChoosing += _playerScreen.OnStartChoosing;

            _scenario.Moved += _fistView.OnMoved;

            _scenario.Moved += _playerScreen.ResultMoveView.OnMoved;

            _scenario.StartChoosing += _fistView.OnStartChoosing;
        }

        private void Start()
        {
            _scenario.Start();
        }

        private void OnDisable()
        {
            _inputRouter.UnSubscribe();

            _input.Played -= _player.PlayWithFist;

            _scenario.PlayerChosen -= _playerScreen.OnPlayerPlayed;

            _scenario.PlayerChosen -= _fistView.OnPlayerChosen;

            _scenario.EnemyChosen -= _fistView.OnEnemyChosen;

            _scenario.AnyWon -= _endScreen.OnAnyWon;

            _endScreen.OnRestartClicked -= _scenario.Start;

            _scenario.Score.Updated -= _playerScreen.OnScoreChanged;

            _scenario.StartChoosing -= _playerScreen.OnStartChoosing;

            _scenario.Moved -= _fistView.OnMoved;
            
            _scenario.Moved -= _playerScreen.ResultMoveView.OnMoved;
            
            _scenario.StartChoosing -= _fistView.OnStartChoosing;
        }
    }
}