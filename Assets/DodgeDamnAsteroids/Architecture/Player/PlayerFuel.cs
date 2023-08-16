using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float fuelConsumptionPerSecond;
    [SerializeField] private int fuelInCanister;

    public static float fuelValue;
    private int maxFuelValue = 100;
    private Player player;

    private void Awake()
    {
        fuelValue = maxFuelValue;
        player = GetComponent<Player>();
    }
    private void Update()
    {
        if (fuelValue > maxFuelValue)
            fuelValue = maxFuelValue;
        if (fuelValue <= 0)
        {
            fuelValue = 0;
            player.KillPlayer();
        }

        ConsumpFuel();
    }
    private void ConsumpFuel()
    {
        fuelValue -= fuelConsumptionPerSecond * Time.deltaTime;
    }
    public void GetCanister()
    {
        fuelValue += fuelInCanister;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Canister"))
        {
            GetCanister();
        }
    }
}
