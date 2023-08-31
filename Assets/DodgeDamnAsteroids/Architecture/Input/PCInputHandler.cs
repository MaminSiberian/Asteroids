using UnityEngine;

public class PCInputHandler : MonoBehaviour, IInputHandler
{
    private Gun gun;

    private void Awake()
    {
        gun = FindAnyObjectByType<Gun>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
    }
    public void Shoot()
    {
        gun.Shoot();
    }
    public float HorizontalSpeed()
    {
        return Input.GetAxis("Horizontal");
    }
    public float VerticalSpeed()
    {
        return Input.GetAxis("Vertical");
    }
}
