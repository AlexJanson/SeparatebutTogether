using System;
using SeparateButTogether.Variables;
using UnityEngine;

namespace SeparateButTogether.Level
{
    /// <summary>
    /// Goal for the player when they reach the end of a level.
    /// </summary>
    public class Goal : MonoBehaviour
    {
        public BoolVariable playerHasReachedGoal;

        private Animator _animator;
        private static readonly int IsClosed = Animator.StringToHash("IsClosed");

        private void Start() => _animator = GetComponent<Animator>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            playerHasReachedGoal.Value = true;
            
            _animator.SetBool(IsClosed, playerHasReachedGoal.Value);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            playerHasReachedGoal.Value = false;
            
            _animator.SetBool(IsClosed, playerHasReachedGoal.Value);
        }
    }
}
