using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeathEvent;
    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void KillPlayer()
    {
        OnPlayerDeath();
        this.gameObject.SetActive(false);
    }
    private void OnPlayerDeath()
    {
        OnPlayerDeathEvent?.Invoke();
    }
}
