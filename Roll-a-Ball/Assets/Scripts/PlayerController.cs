using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float _speed = 0.0f;

    private Rigidbody _rb;
    private float _movementX, _movementY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue __movementValue)
    {
        Vector2 __movementVecotor = __movementValue.Get<Vector2>();

        _movementX = __movementVecotor.x;
        _movementY = __movementVecotor.y;
    }

    void FixedUpdate()
    {
        Vector3 __movement = new Vector3(_movementX, 0.0f, _movementY);
        _rb.AddForce(__movement * _speed);
    }
}