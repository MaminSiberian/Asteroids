using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    public static GameObject pauseScreen { get; private set; }
    private static float normalTimeScale = 1f;
    private static float pausedTimeScale = 0;

    private void OnEnable()
    {
        pauseScreen = _pauseScreen;
        UnpauseGame();
    }
    public static void PauseGame()
    {
        Time.timeScale = pausedTimeScale;
        pauseScreen.SetActive(true);
    }
    public static void UnpauseGame()
    {
        Time.timeScale = normalTimeScale;
        pauseScreen.SetActive(false);
    }
}
