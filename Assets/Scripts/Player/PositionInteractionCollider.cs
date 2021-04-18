using UnityEngine;
using SeparateButTogether.Variables;

namespace SeparateButTogether.Player
{
    /// <summary>
    /// Handle the position of the interaction collider.
    /// </summary>
    public class PositionInteractionCollider : MonoBehaviour
    {
        public Vector2Variable playerMoveDirection;

        private CircleCollider2D _interactCollider;

        private void Start() => _interactCollider = GetComponent<CircleCollider2D>();

        private void Update()
        {
            // We want the collider to be at the position where the player is looking.
            // So we offset the collider in the direction that the player is looking
            // by a certain amount.
            float radius = _interactCollider.radius * 2;
            _interactCollider.offset = new Vector2(playerMoveDirection.Value.x * radius,
                playerMoveDirection.Value.y * radius);
        }
    }
}
