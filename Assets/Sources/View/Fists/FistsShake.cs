using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Sources.View.Fists
{
    [Serializable]
    public class FistsShake
    {
        [SerializeField] private Transform[] _shakers;

        [Min(0)] [SerializeField] private float _duration = 1;

        [SerializeField] private Vector3 _strength = Vector3.forward;

        [Min(0)] [SerializeField] private float _strengthForce = 90;

        [Min(0)] [SerializeField] private int _vibrato = 2;

        [Min(0)] [SerializeField] private int _randomness = 10;

        public void StartShake()
        {
            foreach (var shaker in _shakers)
            {
                TweenerCore<Quaternion, Vector3, QuaternionOptions> tween = shaker.DOLocalRotate(Vector3.zero, .3f);
                
                tween.onComplete += delegate
                {
                    shaker.DOShakeRotation(_duration, _strength * _strengthForce, _vibrato, _randomness).SetLoops(-1);
                };
            }
        }

        public void StopShake()
        {
            foreach (var shaker in _shakers)
            {
                shaker.DOKill();
            }
        }
    }
}