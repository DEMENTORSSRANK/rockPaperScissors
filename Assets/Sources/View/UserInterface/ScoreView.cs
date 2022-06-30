using System;
using Sources.Model.GameScenarios.Parameters;
using TMPro;
using UnityEngine;

namespace Sources.View.UserInterface
{
    [Serializable]
    public class ScoreView
    {
        [SerializeField] private TMP_Text _text;

        [TextArea] [SerializeField] private string _format = "{0}/{1} ({2})";

        public void Update(IReadOnlyGameScore gameScore)
        {
            _text.text = string.Format(_format, gameScore.Player, gameScore.Enemy, gameScore.ToWin);
        }
    }
}