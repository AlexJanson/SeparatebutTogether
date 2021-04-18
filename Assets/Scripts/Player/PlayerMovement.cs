using UnityEngine;
using UnityEngine.InputSystem;
using SeparateButTogether.Variables;

namespace SeparateButTogether.Player
{
    /// <summary>
    /// Handle the player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 4f;
        public float smoothening = 5f;

        public Vector2Variable playerMoveDirection;
        public BoolVariable isPlayerInputDisabled;

        private Rigidbody2D _rigidbody2D;
        private UnityEngine.InputSystem.PlayerInput _input;
        private InputAction _moveAction;

        private Vector2 _moveSpeed;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            // Get the action that will be fired when the 'move' keys are pressed.
            _input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
            _moveAction = _input.currentActionMap.FindAction("Move");
            // Subscribe to the event.
            _moveAction.performed += 
                context => playerMoveDirection.Value = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            // Player shouldn't stop immediately when the keys are released.
            // So we SmoothDamp the value to 0, 0 with SmoothDamp.
            Vector2 velocity = Vector2.zero;
            Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
            _moveSpeed = Vector2.SmoothDamp(_moveSpeed, moveDirection, ref velocity, smoothening);
            
            // When the players input is disabled (during level transition) don't move the player.
            // But we do want to calculate the SmoothDamp still. Otherwise the player will still
            // slide after level transitions.
            if (isPlayerInputDisabled.Value) return;
            
            _rigidbody2D.MovePosition((Vector2)transform.position + _moveSpeed * (speed * Time.fixedDeltaTime));
        }
    }
}
