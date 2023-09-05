using UnityEngine;
using TMPro;

namespace UI
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private void Update()
        {
            ShowFuelLevel();
        }
        private void ShowFuelLevel()
        {
            text.text = ((int)Gameplay.Fuel.fuelValue).ToString() + "%";
        }
    }
}
