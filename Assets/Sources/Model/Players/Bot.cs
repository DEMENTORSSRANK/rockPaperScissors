using System.Threading.Tasks;
using Sources.Model.Fists;

namespace Sources.Model.Players
{
    public class Bot : BasePlayer
    {
        private readonly FistGenerator _fistGenerator;

        public Bot()
        {
            _fistGenerator = new FistGenerator();
        }

        public override async Task<FistType> MakeChoiceAsync()
        {
            await Task.Delay(1);
            
            return _fistGenerator.GenerateRandom();
        }
    }
}