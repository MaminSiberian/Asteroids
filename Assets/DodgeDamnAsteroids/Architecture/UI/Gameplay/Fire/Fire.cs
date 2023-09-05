using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image image;

        private void Update()
        {
            text.enabled = Gameplay.Fire.isOnFire;
            image.enabled= Gameplay.Fire.isOnFire;

            ShowFireLevel();
        }
        private void ShowFireLevel()
        {
            text.text = ((int)Gameplay.Fire.fireLevel).ToString() + "%";
        }
    }
}
