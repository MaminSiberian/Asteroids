using UnityEngine;

public class PCInputHandler : MonoBehaviour, IInputHandler
{
    private Gameplay.Gun gun;

    private void Awake()
    {
        gun = FindAnyObjectByType<Gameplay.Gun>();
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
