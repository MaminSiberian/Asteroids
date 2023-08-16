using TMPro;
using UnityEngine;

public class TestText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        ShowInfo();
    }
    private void ShowInfo()
    {
        text.text = $"Heath: {PlayerHealth.healthValue}, Fuel: {(int) PlayerFuel.fuelValue}, " +
            $"IsOnFire: {PlayerFire.isOnFire}, FireLevel: {PlayerFire.fireValue}";
    }
}
