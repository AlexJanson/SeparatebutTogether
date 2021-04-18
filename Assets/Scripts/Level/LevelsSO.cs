using System;
using System.Collections.Generic;
using UnityEngine;

namespace SeparateButTogether.Level
{
    /// <summary>
    /// Holds all of the level scriptable objects in a list.
    /// </summary>
    [CreateAssetMenu(fileName = "Levels", menuName = "Custom/Levels")]
    public class LevelsSO : ScriptableObject
    {
        public List<LevelSO> levels = new List<LevelSO>();
        public LevelStateSO levelState;
        private int _currentLevel = 0;
        
        public event Action<LevelSO> NextLevel;

        private void HandleNextLevel() => NextLevel?.Invoke(GetNextLevel());
        
        private LevelSO GetNextLevel()
        {
            if (_currentLevel + 1 < levels.Count)
                _currentLevel++;

            return levels[_currentLevel];
        }
        
        private void OnEnable()
        {
            levelState.NextLevel += HandleNextLevel;
            _currentLevel = 0;
        }

        private void OnDisable() => levelState.NextLevel -= HandleNextLevel;
    }
}
