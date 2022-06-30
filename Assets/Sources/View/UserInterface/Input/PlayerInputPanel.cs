using System;
using Sources.Input;
using Sources.Model.Fists;
using UnityEngine;

namespace Sources.View.UserInterface.Input
{
    [Serializable]
    public class PlayerInputPanel : IResultInputHandler
    {
        [SerializeField] private ResultTypedInput[] _inputs;

        [SerializeField] private GameObject _panel;
        
        public event Action<FistType> OnPlayerResultPressed;

        public void SetActive(bool isActive) => _panel.SetActive(isActive);

        public void InitButtons()
        {
            foreach (var input in _inputs)
            {
                input.Button.onClick.AddListener(delegate
                {
                    OnPlayerResultPressed?.Invoke(input.Fist);
                });
            }
        }
    }
}