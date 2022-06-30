using System;
using Sources.Model.Fists;
using UnityEngine;

namespace Sources.View
{
    [Serializable]
    public struct SpriteOfFist
    {
        [SerializeField] private Sprite _sprite;

        [SerializeField] private FistType _fist;

        public Sprite Sprite => _sprite;

        public FistType Fist => _fist;
    }
}