using System;
using Sources.Model.Fists;

namespace Sources.Input
{
    public class PlayerInput
    {
        public event Action<FistType> Played;

        public void Play(FistType fist)
        {
            Played?.Invoke(fist);
        }
    }
}