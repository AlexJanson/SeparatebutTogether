using System;
using UnityEngine;
using SeparateButTogether.Variables;

namespace SeparateButTogether.Level
{
    /// <summary>
    /// State of the level. (like if both players have reached the goal)
    /// </summary>
    [CreateAssetMenu(fileName = "LevelState", menuName = "Custom/Level State")]
    public class LevelStateSO : ScriptableObject
    {
        public BoolVariable playerOneHasReachedGoal;
        public BoolVariable playerTwoHasReachedGoal;
        public bool resetBools = true;

        public event Action NextLevel;

        public bool PlayersHaveReachedGoal() => playerOneHasReachedGoal.Value && playerTwoHasReachedGoal.Value;
        
        private void OnEnable()
        {
            if (resetBools)
            {
                playerOneHasReachedGoal.Value = false;
                playerTwoHasReachedGoal.Value = false;
            }

            playerOneHasReachedGoal.OnChange += OnChangePlayerOne;
            playerTwoHasReachedGoal.OnChange += OnChangePlayerTwo;
        }

        private void OnDisable()
        {
            playerOneHasReachedGoal.OnChange -= OnChangePlayerOne;
            playerTwoHasReachedGoal.OnChange -= OnChangePlayerTwo;
        }

        private void OnChangePlayerOne(bool _) => CheckForNextLevel();
        private void OnChangePlayerTwo(bool _) => CheckForNextLevel();

        private void CheckForNextLevel()
        {
            if (PlayersHaveReachedGoal())
                NextLevel?.Invoke();
        }
    }
}
