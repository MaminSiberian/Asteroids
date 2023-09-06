using UnityEngine;

namespace Gameplay
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private float scoreIncreaseSpeed;

        public static float currentScore { get; private set; }
        public static float bestScore { get; private set; }

        private void Awake()
        {
            currentScore = 0;
            //getBestScore
        }
        private void Update()
        {
            IncreaseScore();
        }
        private void IncreaseScore()
        {
            currentScore += scoreIncreaseSpeed * Time.deltaTime;
        }
    }
}
