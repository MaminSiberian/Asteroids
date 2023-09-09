using UnityEngine;
using TMPro;
using DG.Tweening;

public class Alarm : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color white = Color.white;
    private Color red = Color.red;
    private float speed = 1f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.color = white;
    }

    private void Update()
    {
        if (text.color == white)
            text.DOColor(red, speed);

        if (text.color == red)
            text.DOColor(white, speed);
    }
}
