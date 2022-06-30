using System;

namespace Sources.Model.GameScenarios.Parameters
{
    public interface IReadOnlyGameScore
    {
        public int Player { get; }
        
        public int Enemy { get; }
        
        public int ToWin { get; }

        public event Action<IReadOnlyGameScore> Updated;
    }
}