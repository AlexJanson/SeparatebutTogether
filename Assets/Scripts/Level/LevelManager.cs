using System.Collections;
using SeparateButTogether.Variables;
using UnityEngine;

namespace SeparateButTogether.Level
{
    public class LevelManager : MonoBehaviour
    {
        public LevelsSO levels;
        public Transform playerOnePosition;
        public Transform playerTwoPosition;
        public BoolVariable isPlayerInputDisabled;
        public Animator fadeScreenAnimator;

        private LevelCamera _levelCamera;

        private void Awake() => _levelCamera = FindObjectOfType<LevelCamera>();

        private void Start() => levels.NextLevel += OnNextLevel;

        private void OnNextLevel(LevelSO nextLevel) => StartCoroutine(StartNextLevel(nextLevel));

        // For the level transition.
        private IEnumerator StartNextLevel(LevelSO nextLevel)
        {
            yield return new WaitForSeconds(.3f);
            // Disable input for the player
            isPlayerInputDisabled.Value = true;
            
            // Fade the screen to black
            fadeScreenAnimator.Play("Fade_Screen_Out");
            yield return new WaitForSeconds(1f);
            
            // After the fade teleport the player and camera to the next level area
            _levelCamera.NextLevel(nextLevel);

            playerOnePosition.position = nextLevel.playerOneSpawnPosition.position;
            playerTwoPosition.position = nextLevel.playerTwoSpawnPosition.position;
            
            // Fade out the screen
            fadeScreenAnimator.Play("Fade_Screen_In");
            yield return new WaitForSeconds(1f);
            
            // Enable input for the player
            isPlayerInputDisabled.Value = false;
        }

        private void OnDestroy() => levels.NextLevel -= OnNextLevel;
    }
}
