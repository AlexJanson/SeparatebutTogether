using System;
using UnityEngine;

namespace SeparateButTogether.Interactables
{
    /// <summary>
    /// Use this class for activatable objects in the game. (like levers, pressure plates and buttons)
    /// </summary>
    public abstract class Activatable : Interactable
    {
        protected bool _isActive;
        public Sprite inactiveSprite;
        public Sprite activeSprite;
        private SpriteRenderer _spriteRenderer;

        // When the state changes this event is called.
        public event Action<bool> OnActivated;

        private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public abstract override void Interact();

        protected virtual void Activate()
        {
            _isActive = !_isActive;
            
            // Change the active sprite of the object.
            Sprite currentSprite = _isActive ? activeSprite : inactiveSprite;
            outlineRenderer.sprite = currentSprite;
            _spriteRenderer.sprite = currentSprite;
            
            OnActivated?.Invoke(_isActive);
        }
    }
}
