using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;

        private Animator animator;
        private string refuelAnimName = "Refuel";

        private void OnEnable()
        {
            animator = image.GetComponent<Animator>();
            Gameplay.Fuel.OnGetCanisterEvent += OnGetCanister;
        }
        private void OnDisable()
        {
            Gameplay.Fuel.OnGetCanisterEvent -= OnGetCanister;
        }
        private void Update()
        {
            ShowFuelLevel();
        }
        private void ShowFuelLevel()
        {
            text.text = ((int)Gameplay.Fuel.fuelValue).ToString() + "%";
        }
        private void OnGetCanister()
        {
            animator.Play(refuelAnimName);
        }
    }
}
