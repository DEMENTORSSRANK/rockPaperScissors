using System;
using System.Threading.Tasks;
using Sources.Model.Fists;

namespace Sources.Model.Players
{
    public class Player : BasePlayer
    {
        private bool _waitingInput;

        private FistType _lastFist;

        public void PlayWithFist(FistType fist)
        {
            if (!_waitingInput)
                throw new InvalidOperationException("Not waiting for input, cant play");

            _lastFist = fist;

            _waitingInput = false;
        }
        
        public override async Task<FistType> MakeChoiceAsync()
        {
            _waitingInput = true;
            
            while (_waitingInput)
                await Task.Delay(1);

            return _lastFist;
        }
    }
}