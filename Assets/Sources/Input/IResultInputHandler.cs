using System;
using Sources.Model.Fists;

namespace Sources.Input
{
    public interface IResultInputHandler
    {
        public event Action<FistType> OnPlayerResultPressed;
    }
}