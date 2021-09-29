using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float _speed = 0.0f;
    public TextMeshProUGUI _countText;
    public GameObject _winTextGO;

    private Rigidbody _rb;
    private int _count;
    private float _movementX, _movementY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        _winTextGO.SetActive(false);
    }

    void OnMove(InputValue __movementValue)
    {
        Vector2 __movementVecotor = __movementValue.Get<Vector2>();

        _movementX = __movementVecotor.x;
        _movementY = __movementVecotor.y;
    }

    void SetCountText()
    {
        _countText.text = "Count: " + _count.ToString();
        if (_count >= 12)
            _winTextGO.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 __movement = new Vector3(_movementX, 0.0f, _movementY);
        _rb.AddForce(__movement * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
