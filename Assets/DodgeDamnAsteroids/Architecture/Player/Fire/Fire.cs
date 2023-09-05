using UnityEngine;

namespace Gameplay 
{ 
    public class Fire : MonoBehaviour
    {
        [SerializeField] private float fireIncreasePerSecond;
        [SerializeField] private float fireDecreaseByExtinguish;

        public static bool isOnFire { get; private set; }
        public static float fireValue { get; private set; }
        private int maxFireValue = 100;
        private Player player;
        private string extingTag = TagStorage.extingTag;
        private string asterTag = TagStorage.asterTag;

        private void Awake()
        {
            player = GetComponent<Player>();
            fireValue = 1;
        }
        private void Update()
        {
            if (fireValue <= 0)
            {
                fireValue = 1;
                isOnFire = false;
            }
            if (fireValue >= maxFireValue)
            {
                fireValue = maxFireValue;
                isOnFire = false;
                player.KillPlayer();
            }

            if (isOnFire) BurnPlayer();
        }
        public void BurnPlayer()
        {
            fireValue += fireIncreasePerSecond * Time.deltaTime;
        }
        private void Extinguish()
        {
            fireValue -= fireDecreaseByExtinguish;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(extingTag))
            {
                Extinguish();
            }
            if (collision.CompareTag(asterTag))
            {
                isOnFire = true;
            }
        }
    }
}
