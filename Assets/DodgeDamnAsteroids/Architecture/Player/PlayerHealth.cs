using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _startHealthValue = 3;
    [SerializeField] private int _maxHealthValue = 6;
    public static int startHealthValue { get; private set; }
    public static int maxHealthValue { get; private set; }
    public static int healthValue { get; private set; }

    private Player player;
    private string heartTag = TagStorage.heartTag;
    private string asterTag = TagStorage.asterTag;

    private void Awake()
    {
        player = GetComponent<Player>();
        startHealthValue = _startHealthValue;
        maxHealthValue = _maxHealthValue;
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
        if (collision.CompareTag(heartTag))
        {
            IncreaseHealth();
        }
        if (collision.CompareTag(asterTag))
        {
            DecreaseHealth();
        }
    }
}
