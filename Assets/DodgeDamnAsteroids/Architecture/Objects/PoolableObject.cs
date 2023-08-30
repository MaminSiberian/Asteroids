using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    protected float maxX = 3;
    protected float maxY = 8;

    protected virtual void Update()
    {
        CheckObjPosition();
    }

    protected void CheckObjPosition()
    {
        if (Mathf.Abs(this.transform.position.x) >= maxX || Mathf.Abs(this.transform.position.y) >= maxY)
            this.gameObject.SetActive(false);
    }
}
