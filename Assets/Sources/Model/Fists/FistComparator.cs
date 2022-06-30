using System.Collections.Generic;
using Sources.Model.GameScenarios;

namespace Sources.Model.Fists
{
    public class FistComparator
    {
        /// <summary>
        /// Left type bite right
        /// </summary>
        private readonly Dictionary<FistType, FistType> _biteMap = new Dictionary<FistType, FistType>()
        {
            {FistType.Paper, FistType.Rock},
            {FistType.Rock, FistType.Scissor},
            {FistType.Scissor, FistType.Paper}
        };

        public ResultType Compare(FistType first, FistType second)
        {
            if (first == second)
                return ResultType.Draw;

            bool isWin = _biteMap[first] == second;

            return isWin ? ResultType.Win : ResultType.Lose;
        }
    }
}