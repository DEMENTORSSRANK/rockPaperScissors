using System;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Sources.Model.GameScenarios;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Result
{
    [Serializable]
    public class ResultMoveView
    {
        [SerializeField] private Image _panel;

        [SerializeField] private ColorOfResult[] _colorsOfResults;

        [Min(0)] [SerializeField] private float _durationViewColor = .2f;

        [SerializeField] private Color _reset = Color.clear;
        
        public void OnMoved(ResultType result)
        {
            _panel.color = _reset;

            TweenerCore<Color, Color, ColorOptions> tween = _panel.DOColor(GetColorOfResult(result), _durationViewColor);
            
            tween.onComplete += delegate
            {
                _panel.DOColor(_reset, _durationViewColor);
            };
        }

        private Color GetColorOfResult(ResultType result) => _colorsOfResults.First(x => x.Result == result).Color;
    }
}