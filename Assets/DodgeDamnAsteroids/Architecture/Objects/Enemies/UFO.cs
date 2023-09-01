using UnityEngine;

public class UFO : PoolableObject
{
    [SerializeField] private float projectileForce;
    [SerializeField] private float reloadTime;

    private Player player;
    private string projectileTag;
    private bool isLoaded = false;
    private float timer = 0f;
    private int forceMultiplier = 50;

    private void OnEnable()
    {
        projectileTag = TagStorage.UFOProjectileTag;
        player = FindAnyObjectByType<Player>();
    }
    protected override void Update()
    {
        base.Update();
        
        if (isLoaded)
        {
            Shoot();
            isLoaded = false;
        }
        else
            Reload();
    }
    private void Reload()
    {
        if (timer >= reloadTime)
        {
            isLoaded = true;
            timer -= reloadTime;
        }
        else
            timer += Time.deltaTime;
    }
    private void Move()
    {
        
    }
    private UFOProjectile Shoot()
    {
        var obj = PoolManager.GetObject(projectileTag);
        obj.transform.position = this.transform.position;
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        obj.GetComponent<Rigidbody2D>().AddForce(direction * projectileForce * forceMultiplier);

        return (UFOProjectile)obj;
    }
}
