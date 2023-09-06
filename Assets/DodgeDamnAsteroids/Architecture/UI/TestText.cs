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
        text.text = $"CurrentScore: {(int)Gameplay.ScoreCounter.currentScore}";
    }
}
