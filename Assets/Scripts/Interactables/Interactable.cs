using UnityEngine;

namespace SeparateButTogether.Interactables
{
    /// <summary>
    /// Use this class when you want to make an interactable gameobject.
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        public SpriteRenderer outlineRenderer;

        // This method gets called from the PlayerInteract class.
        // Override this method to create your own game logic.
        public abstract void Interact();
        
        // When the interaction collider of the player overlaps
        // the collider of the object we display an outline.
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player Interact")) return;

            outlineRenderer.enabled = true;
        }
        
        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player Interact")) return;

            outlineRenderer.enabled = false;
        }
    }
}
