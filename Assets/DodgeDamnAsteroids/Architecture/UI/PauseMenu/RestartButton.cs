using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        button.onClick.AddListener(Restart);
    }
    private void OnDisable()
    {
        button?.onClick.RemoveListener(Restart);
    }
    private void Restart()
    {
        SceneDirector.RestartScene();
    }
}
