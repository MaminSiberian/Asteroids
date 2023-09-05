using UnityEngine;

namespace Gameplay 
{ 
    public class Fire : MonoBehaviour
    {
        [SerializeField] private float fireIncreaseSpeed;
        [SerializeField] private float fireDecreaseByExtinguish;
        [SerializeField] private float extingSpeed;

        public static bool isOnFire { get; private set; }
        public static float fireLevel { get; private set; }
        private int maxFireValue = 100;
        private Player player;
        private string extingTag = TagStorage.extingTag;
        private string asterTag = TagStorage.asterTag;
        private bool isExtinguishing;
        private float newFireLevel;

        private void Awake()
        {
            player = GetComponent<Player>();
            fireLevel = 1;
        }
        private void Update()
        {
            if (fireLevel <= 0)
            {
                fireLevel = 1;
                isOnFire = false;
                isExtinguishing = false;
            }
            if (fireLevel >= maxFireValue)
            {
                fireLevel = maxFireValue;
                isOnFire = false;
                player.KillPlayer();
            }

            if (isExtinguishing)
            {
                Extinguish();
                return;
            }

            if (isOnFire) BurnPlayer();
        }
        public void BurnPlayer()
        {
            fireLevel += fireIncreaseSpeed * Time.deltaTime;
        }
        private void GetExtinguisher()
        {
            if (isExtinguishing)
                newFireLevel -= fireDecreaseByExtinguish;
            else
                newFireLevel = fireLevel - fireDecreaseByExtinguish;

            if (newFireLevel < 0) newFireLevel = 0;

            isExtinguishing = true;
        }
        private void Extinguish()
        {
            if (fireLevel <= newFireLevel)
            {
                isExtinguishing = false;
                return;
            }

            fireLevel -= extingSpeed * Time.deltaTime;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(extingTag))
            {
                GetExtinguisher();
            }
            if (collision.CompareTag(asterTag))
            {
                isOnFire = true;
            }
        }
    }
}
