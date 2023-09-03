using UnityEngine;

public class UFO : PoolableObject
{
    [SerializeField] private int startHealth = 3;
    [Space]
    [SerializeField] private float projectileForce;
    [SerializeField] private float minReloadTime;
    [SerializeField] private float maxReloadTime;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minYpos = 1.5f;
    [SerializeField] private float maxYpos = 4;
    [SerializeField] private float maxXpos = 1.5f;

    private Player player;
    private Vector3 targetPos;
    private int health;
    private string projectileTag = TagStorage.UFOProjectileTag;
    private bool isLoaded = false;
    private float timer = 0f;
    private int forceMultiplier = 50;
    private int speedMultiplier = 10;
    private float reloadTime;
    private string bombTag = TagStorage.bombTag;
    private float distance = 0.1f;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player>();
        health = startHealth;
        SetReloadTime();
        SetTargetPos();
    }
    protected override void Update()
    {
        base.Update();
        if (player == null) return;

        if (isLoaded)
        {
            Shoot();
            isLoaded = false;
        }
        else
            Reload();

        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bombTag))
            GetDamage();
    }
    private void Reload()
    {
        if (timer >= reloadTime)
        {
            isLoaded = true;
            timer -= reloadTime;
            SetReloadTime();
        }
        else
            timer += Time.deltaTime;
    }
    private void Move()
    {
        if (Vector3.Distance(this.transform.position, targetPos) <= distance) SetTargetPos();

        this.transform.position = 
            Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed / speedMultiplier * Time.deltaTime);
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
    private void SetReloadTime()
    {
        reloadTime = Random.Range(minReloadTime, maxReloadTime);
    }
    private void GetDamage()
    {
        health--;

        if (health <= 0) KillUFO();
    }
    private void KillUFO()
    {
        this.gameObject.SetActive(false);
    }
    private void SetTargetPos()
    {
        targetPos = new Vector3(Random.Range(-maxXpos, maxXpos), Random.Range(minYpos, maxYpos), 0f);
    }
}
