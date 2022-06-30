using System.Linq;
using Sources.Model.Fists;
using Sources.Model.GameScenarios;
using UnityEngine;

namespace Sources.View.Fists
{
    public class FistView : MonoBehaviour
    {
        [SerializeField] private SpriteOfFist[] _spritesFist;

        [SerializeField] private SpriteRenderer _player;

        [SerializeField] private SpriteRenderer _enemy;

        [SerializeField] private FistsShake _shaker;

        private Sprite _resetSprite;

        public void OnPlayerChosen(FistType fist) => ApplyRendererToChooseFist(_player, fist);

        public void OnEnemyChosen(FistType fist) => ApplyRendererToChooseFist(_enemy, fist);

        public void OnMoved(ResultType result)
        {
            Reset();
        }

        public void OnStartChoosing()
        {
            _shaker.StartShake();
        }

        private Sprite GetSpriteOfFist(FistType fist) => _spritesFist.First(x => x.Fist == fist).Sprite;

        private void ApplyRendererToChooseFist(SpriteRenderer spriteRenderer, FistType fist)
        {
            spriteRenderer.sprite = GetSpriteOfFist(fist);

            _shaker.StopShake();
        }

        private void Awake()
        {
            _resetSprite = GetSpriteOfFist(FistType.Rock);
        }

        private void Reset()
        {
            _player.sprite = _resetSprite;

            _enemy.sprite = _resetSprite;

            _shaker.StopShake();
        }
    }
}