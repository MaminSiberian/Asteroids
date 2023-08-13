using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveSpeed;
    private float rotationSpeed = 20;
    private int speedMultiplier = 10;
    private Player player;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GetSpeed();
    }
    private void GetSpeed()
    {
        this.moveSpeed = player._moveSpeed * speedMultiplier;
    }
    private void Update()
    {
        float rotDirection = InputManager.horizontalSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, -rotDirection * rotationSpeed);
    }
    private void FixedUpdate()
    {
        float horizontalSpeed = InputManager.horizontalSpeed;
        float verticalSpeed = InputManager.verticalSpeed;
        rb.velocity = new Vector2(horizontalSpeed * moveSpeed * Time.fixedDeltaTime, verticalSpeed * moveSpeed * Time.fixedDeltaTime);
    }
}
