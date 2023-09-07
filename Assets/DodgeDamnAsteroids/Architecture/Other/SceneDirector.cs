using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneDirector
{
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
