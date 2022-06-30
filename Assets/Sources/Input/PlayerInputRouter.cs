using System;

namespace Sources.Input
{
    public class PlayerInputRouter
    {
        private readonly IResultInputHandler _handler;

        private readonly PlayerInput _input;

        public PlayerInputRouter(IResultInputHandler handler, PlayerInput input)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public void Subscribe()
        {
            _handler.OnPlayerResultPressed += _input.Play;
        }

        public void UnSubscribe()
        {
            _handler.OnPlayerResultPressed -= _input.Play;
        }
    }
}