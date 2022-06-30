using System;
using Sources.Model.Fists;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Input
{
    [Serializable]
    public struct ResultTypedInput
    {
        [SerializeField] private Button _button;

        [SerializeField] private FistType _fist;

        public Button Button => _button;

        public FistType Fist => _fist;
    }
}