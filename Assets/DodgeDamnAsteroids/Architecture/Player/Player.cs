using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    public float _moveSpeed { get; private set; }
    [SerializeField] private float maxX;
    public int _maxX { get; private set; }

    private void Awake()
    {
        this.gameObject.AddComponent<Movement>();
        this._moveSpeed = this.moveSpeed;
    }
}
