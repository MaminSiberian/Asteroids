
public class UFOProjectile : PoolableObject
{
    private void Awake()
    {
        this.gameObject.AddComponent<ObstacleCollisionHandler>();
    }
}
