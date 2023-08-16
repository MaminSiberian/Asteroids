using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = ObjectsManager._obstaclesSpeed;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
