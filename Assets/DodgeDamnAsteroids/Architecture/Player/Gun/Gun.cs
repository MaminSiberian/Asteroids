using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float force;
    private int forceMultiplier = 50;
    private string bombTag = TagStorage.bombTag;

    public Bomb Shoot()
    {
        var obj = PoolManager.GetObject(bombTag);
        obj.transform.position = this.transform.position;
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force * forceMultiplier);

        return (Bomb)obj;
    }
}
