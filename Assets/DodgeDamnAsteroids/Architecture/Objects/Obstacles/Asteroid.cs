
using UnityEngine;

public class Asteroid : Obstacle
{
    private string bombTag = TagStorage.bombTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bombTag))
            BlowUp();
    }
    public void BlowUp()
    {
        this.gameObject.SetActive(false);
    }
}
