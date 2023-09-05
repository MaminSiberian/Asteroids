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
        text.text = $"IsOnFire: {Gameplay.Fire.isOnFire}, FireLevel: {Gameplay.Fire.fireLevel}";
    }
}
