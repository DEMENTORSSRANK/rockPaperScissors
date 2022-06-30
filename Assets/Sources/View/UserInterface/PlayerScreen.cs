using Sources.Input;
using Sources.Model.Fists;
using Sources.Model.GameScenarios.Parameters;
using Sources.View.UserInterface.Input;
using Sources.View.UserInterface.Result;
using UnityEngine;

namespace Sources.View.UserInterface
{
    public class PlayerScreen : MonoBehaviour
    {
        [SerializeField] private PlayerInputPanel _playerPlayerInputPanel;

        [SerializeField] private ScoreView _scoreView;

        [SerializeField] private ResultMoveView _resultMoveView;

        public IResultInputHandler PlayerInputPanel => _playerPlayerInputPanel;

        public ResultMoveView ResultMoveView => _resultMoveView;

        public void OnStartChoosing()
        {
            _playerPlayerInputPanel.SetActive(true);
        }

        public void OnScoreChanged(IReadOnlyGameScore gameScore)
        {
            _scoreView.Update(gameScore);
        }

        public void OnPlayerPlayed(FistType type)
        {
            _playerPlayerInputPanel.SetActive(false);
        }

        private void Start()
        {
            _playerPlayerInputPanel.InitButtons();
        }
    }
}