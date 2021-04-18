using System.Collections.Generic;
using SeparateButTogether.Interactables;
using SeparateButTogether.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeparateButTogether.Player
{
    /// <summary>
    /// Handle the player interaction with objects.
    /// </summary>
    public class PlayerInteract : MonoBehaviour
    {
        public Collider2D interactCollider;
        public BoolVariable isPlayerInputDisabled;
        
        private UnityEngine.InputSystem.PlayerInput _input;
        private InputAction _interactAction;
        
        private void Start()
        {
            // Get the action that will be fired when the 'Interact' key is pressed.
            _input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
            _interactAction = _input.currentActionMap.FindAction("Interact");
            // Subscribe to the event.
            _interactAction.performed += OnInteract;
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            if (isPlayerInputDisabled.Value) return;
            
            // Get a list of all the overlapping colliders.
            ContactFilter2D filter2D = new ContactFilter2D().NoFilter();
            List<Collider2D> colliders = new List<Collider2D>();
            interactCollider.OverlapCollider(filter2D, colliders);

            foreach (Collider2D col in colliders)
            {
                // Check if that object has the 'Interactable' component then call the interact function.
                if (!col.TryGetComponent(out Interactable interactable)) continue;
                interactable.Interact();
            }
        }
    }
}