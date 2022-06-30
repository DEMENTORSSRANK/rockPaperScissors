using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private GameObject[] _winActive;

        [SerializeField] private GameObject[] _loseActive;

        [SerializeField] private Button _restart;
        
        public event Action OnRestartClicked;

        public void OnAnyWon(bool isPlayer)
        {
            _winActive.ToList().ForEach(x => x.SetActive(isPlayer));

            _loseActive.ToList().ForEach(x => x.SetActive(!isPlayer));
            
            _restart.gameObject.SetActive(true);
        }

        private void RestartClicked()
        {
            InActiveAll();
            
            OnRestartClicked?.Invoke();
        }

        private void InActiveAll()
        {
            _winActive.ToList().ForEach(x => x.SetActive(false));
            
            _loseActive.ToList().ForEach(x => x.SetActive(false));
            
            _restart.gameObject.SetActive(false);
        }
        
        private void Start()
        {
            _restart.onClick.AddListener(RestartClicked);
            
            InActiveAll();
        }
    }
}