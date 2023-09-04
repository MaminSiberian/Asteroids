using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int maxAmmo;
    [SerializeField] private float force;
    [SerializeField] private float reloadTime;

    public static int ammo { get; private set; }
    public static float reloadProgress;

    private int forceMultiplier = 50;
    private string bombTag = TagStorage.bombTag;
    private float timer = 0f;

    private void Start()
    {
        ammo = maxAmmo;
    }
    private void Update()
    {
        if (ammo > maxAmmo) ammo = maxAmmo;
        if (ammo < 0) ammo = 0;

        if (ammo < maxAmmo)
        {
            Reload();
            reloadProgress = timer / reloadTime;
        }
        else
            reloadProgress = 1f;
    }
    public void Shoot()
    {
        if (ammo <= 0) return;

        var obj = PoolManager.GetObject(bombTag);
        obj.transform.position = this.transform.position;
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force * forceMultiplier);

        ammo--;
    }
    private void Reload()
    {
        if (timer >= reloadTime)
        {
            ammo++;
            timer -= reloadTime;
        }
        else
            timer += Time.deltaTime;
    }
}
