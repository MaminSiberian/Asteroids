using UnityEngine;

namespace Gameplay
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private float scoreIncreaseSpeed;

        public static float currentScore { get; private set; }
        public static float bestScore { get; private set; }

        private bool playerIsAlive;

        private void Awake()
        {
            playerIsAlive = true;
            currentScore = 0;
            //getBestScore
        }
        private void OnEnable()
        {
            Player.OnPlayerDeathEvent += OnPlayerDeath;
        }
        private void OnDisable()
        {
            Player.OnPlayerDeathEvent -= OnPlayerDeath;
        }
        private void Update()
        {
            if (playerIsAlive) IncreaseScore();
        }
        private void IncreaseScore()
        {
            currentScore += scoreIncreaseSpeed * Time.deltaTime;
        }
        private void OnPlayerDeath()
        {
            playerIsAlive = false;
        }
    }
}
