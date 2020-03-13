using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2;
    [SerializeField]
    private float _jumpForce = 220f;
    [SerializeField]
    private float _speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Movement()
    {

        float move = Input.GetAxisRaw("Horizontal");
        _rigidbody2.velocity = new Vector2(move * _speed, _rigidbody2.velocity.y);
    }

    void Jump()
    {
        Debug.Log(_rigidbody2.velocity.y);
        if (_rigidbody2.velocity.y == 0)
            _rigidbody2.AddForce(Vector2.up * _jumpForce);
    }

}
