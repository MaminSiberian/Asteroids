using UnityEngine;

public class Bomb : PoolableObject
{
    [SerializeField] private float minRotationSpeed;
    [SerializeField] private float maxRotationSpeed;
    private string asterTag = PoolManager.asterTag;
    private Rotator rotator;

    private void Awake()
    {
        rotator = this.gameObject.AddComponent<Rotator>();
    }
    private void OnEnable()
    {
        rotator.Init(minRotationSpeed, maxRotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(asterTag))
        {
            collision.GetComponent<Asteroid>().BlowUp();
            this.gameObject.SetActive(false);
        }
    }
}
