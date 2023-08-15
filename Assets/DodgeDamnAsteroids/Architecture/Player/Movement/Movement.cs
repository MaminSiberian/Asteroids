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
    private float horizontalSpeed = InputManager.horizontalSpeed;
    private float verticalSpeed = InputManager.verticalSpeed;
    private float maxX;
    private float maxY;
    private float minY;
    private void OnEnable()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GetSpeed();
        this.maxX = player._maxX; 
        this.maxY = player._maxY;
        this.minY = player._minY;
    }
    private void GetSpeed()
    {
        this.moveSpeed = player._moveSpeed * speedMultiplier;
    }
    private void Update()
    {
        Rotate();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        horizontalSpeed = InputManager.horizontalSpeed;
        verticalSpeed = InputManager.verticalSpeed;

        CheckPosition();

        rb.velocity = new Vector2(horizontalSpeed * moveSpeed * Time.fixedDeltaTime, verticalSpeed * moveSpeed * Time.fixedDeltaTime);
    }
    private void CheckPosition()
    {
        if (this.transform.position.x <= -maxX && horizontalSpeed < 0 || this.transform.position.x >= maxX && horizontalSpeed > 0)
            horizontalSpeed = 0;

        if (this.transform.position.y <= minY && verticalSpeed < 0 || this.transform.position.y >= maxY && verticalSpeed > 0)
            verticalSpeed = 0;
    }
    private void Rotate()
    {
        float rotDirection = InputManager.horizontalSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, -rotDirection * rotationSpeed);
    }
}
