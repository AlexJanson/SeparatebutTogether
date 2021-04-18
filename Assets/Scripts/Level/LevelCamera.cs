using UnityEngine;

namespace SeparateButTogether.Level
{
    public class LevelCamera : MonoBehaviour
    {
        public LevelSO level;

        private void Start() => transform.position = level.cameraPosition;

        public void NextLevel(LevelSO newLevel)
        {
            level = newLevel;
            transform.position = level.cameraPosition;
        }
    }
}
