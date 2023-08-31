using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void KillPlayer()
    {
        this.gameObject.SetActive(false);
    }
}
