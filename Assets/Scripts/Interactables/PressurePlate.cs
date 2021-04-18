using UnityEngine;

namespace SeparateButTogether.Interactables
{
    public class PressurePlate : Activatable
    {
        public override void Interact()
        {
            // Empty since a player can't interact with this object using the interact key.
        }

        // Since pressure plates work when the player stands on top of them,
        // we call the Activate method only then.
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) return;
            
            Activate();
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player")) return;
            
            Activate();
        }
    }
}
