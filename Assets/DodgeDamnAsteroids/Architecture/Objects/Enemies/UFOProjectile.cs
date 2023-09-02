using UnityEngine;

public class UFOProjectile : PoolableObject
{
    private string playerTag = TagStorage.playerTag;

    private void Awake()
    {
        this.gameObject.AddComponent<ObstacleCollisionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            this.gameObject.SetActive(false);
        }
    }
}
