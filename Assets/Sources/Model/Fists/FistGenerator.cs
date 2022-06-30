using System;
using System.Linq;

namespace Sources.Model.Fists
{
    public class FistGenerator
    {
        private static int FistsCount => ((FistType[]) Enum.GetValues(typeof(FistType))).Select(x => (int) x).Max() + 1;

        public FistType GenerateRandom()
        {
            var random = new Random();

            return (FistType) random.Next(0, FistsCount);
        }
    }
}