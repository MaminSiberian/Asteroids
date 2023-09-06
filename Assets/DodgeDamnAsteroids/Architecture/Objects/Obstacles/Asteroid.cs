
using UnityEngine;

public class Asteroid : Obstacle
{
    private string bombTag = TagStorage.bombTag;
    private string destructionTag = TagStorage.asterDestruction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bombTag))
            BlowUp();
    }
    public void BlowUp()
    {
        var obj = PoolManager.GetObject(destructionTag);
        obj.transform.position = this.transform.position;

        this.gameObject.SetActive(false);
    }
}
