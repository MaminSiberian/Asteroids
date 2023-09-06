using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static float normalTimeScale = 1f;
    private static float pausedTimeScale = 0;
    
    public static void PauseGame()
    {
        Time.timeScale = pausedTimeScale;
    }
    public static void UnpauseGame()
    {
        Time.timeScale = normalTimeScale;
    }
}
