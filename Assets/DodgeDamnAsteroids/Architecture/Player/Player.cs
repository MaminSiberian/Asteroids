using UnityEngine;

public class Player : MonoBehaviour
{
    public static string playerTag => "Player";

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void KillPlayer()
    {
        this.gameObject.SetActive(false);
    }
}
