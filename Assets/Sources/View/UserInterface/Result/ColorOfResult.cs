using System;
using Sources.Model.GameScenarios;
using UnityEngine;

namespace Sources.View.UserInterface.Result
{
    [Serializable]
    public struct ColorOfResult
    {
        [SerializeField] private ResultType _result;

        [SerializeField] private Color _color;

        public ResultType Result => _result;

        public Color Color => _color;
    }
}