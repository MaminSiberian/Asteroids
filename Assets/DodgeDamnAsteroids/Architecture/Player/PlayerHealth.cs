using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealthValue = 3;
    [SerializeField] private int maxHealthValue = 6;
    public static int healthValue;

    private Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
        healthValue = startHealthValue;
    }
    public void IncreaseHealth()
    {
        if (healthValue < maxHealthValue)
        healthValue++;
    }
    public void DecreaseHealth()
    {
        if (healthValue > 0)
            healthValue--;
        else
            return;

        if (healthValue <= 0)
            player.KillPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            IncreaseHealth();
        }
        if (collision.CompareTag("Asteroid"))
        {
            DecreaseHealth();
        }
    }
}
