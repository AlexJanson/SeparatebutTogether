using UnityEngine;

namespace SeparateButTogether.Level
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Custom/Level")]
    public class LevelSO : ScriptableObject
    {
        public Vector3 cameraPosition;
        public Transform playerOneSpawnPosition;
        public Transform playerTwoSpawnPosition;
    }
}
