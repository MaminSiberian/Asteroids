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
        text.text = $"Fuel: {(int) Gameplay.Fuel.fuelValue}, " +
            $"IsOnFire: {Gameplay.Fire.isOnFire}, FireLevel: {Gameplay.Fire.fireLevel}," +
            $" Ammo: {Gameplay.Gun.ammo}, Reloading: {Gameplay.Gun.reloadProgress}";
    }
}
