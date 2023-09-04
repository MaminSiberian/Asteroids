using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private List<Image> hearts;

        private int value;
        
        private void Start()
        {
            hearts.ForEach(h => h.enabled = false);

            value = Gameplay.Health.healthValue;
            ShowHealth();
        }
        private void Update()
        {
            if (value != Gameplay.Health.healthValue)
            {
                value = Gameplay.Health.healthValue;
                ShowHealth();
            }
        }

        private void ShowHealth()
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].enabled = i < value;
            }
        }
    }

}
