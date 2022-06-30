using System;

namespace Sources.Model.GameScenarios.Parameters
{
    public class GameScore : IReadOnlyGameScore
    {
        private readonly int _toWin;
        
        public int Player { get; private set; }
        
        public int Enemy { get; private set; }

        public int ToWin => _toWin;

        public bool PlayerWinning => Player > Enemy;

        public event Action<IReadOnlyGameScore> Updated;

        public GameScore(int toWin)
        {
            if (toWin <= 0)
                throw new ArgumentOutOfRangeException(nameof(_toWin));
            
            _toWin = toWin;
        }

        public void ApplyByResultMove(ResultType result)
        {
            switch (result)
            {
                case ResultType.Win:
                    Player++;
                    break;
                case ResultType.Lose:
                    Enemy++;
                    break;
                case ResultType.Draw:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
            
            Updated?.Invoke(this);
        }

        public void Reset()
        {
            Player = 0;

            Enemy = 0;
            
            Updated?.Invoke(this);
        }
        
        public bool CheckIsAnyWin()
        {
            bool isPlayerWin = Player >= _toWin;

            bool isEnemyWin = Enemy >= _toWin;
            
            bool isAnyWin = isPlayerWin || isEnemyWin;

            return isAnyWin;
        }
    }
}