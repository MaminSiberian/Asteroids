using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    public float _moveSpeed { get; private set; }
    [SerializeField] private float maxX;
    public float _maxX { get; private set; }
    [SerializeField] private float minY;
    public float _minY { get; private set; }
    [SerializeField] private float maxY;
    public float _maxY { get; private set; }

    private void Awake()
    {
        this.gameObject.AddComponent<Movement>();
        this._moveSpeed = this.moveSpeed;
        this._maxX = this.maxX;
        this._maxY = this.maxY;
        this._minY = this.minY;
    }
    public void OnPlayerDeath()
    {

    }
}
