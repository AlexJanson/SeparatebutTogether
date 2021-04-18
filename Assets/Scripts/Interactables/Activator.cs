using UnityEngine;

namespace SeparateButTogether.Interactables
{
    /// <summary>
    /// Use this class for object that can be activated. (like doors and bridges)
    /// </summary>
    public abstract class Activator : MonoBehaviour
    {
        public Activatable control;
        public new Collider2D collider;

        public Sprite inactiveSprite;
        public Sprite activeSprite;
        public SpriteRenderer spriteRenderer;

        protected virtual void Start() => control.OnActivated += HandleActivation;
        
        // This gets called whenever the state changes of the control.
        protected virtual void HandleActivation(bool state)
        {
            if (state) Disable();
            else Enable();

            // Change the active sprite of the object.
            Sprite currentSprite = state ? inactiveSprite : activeSprite;
            spriteRenderer.sprite = currentSprite;
        }

        protected virtual void Enable() => collider.enabled = true;

        protected virtual void Disable() => collider.enabled = false;

        protected virtual void OnDestroy() => control.OnActivated -= HandleActivation;
    }
}
