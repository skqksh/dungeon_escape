using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rbody;
    [SerializeField]
    private float _jumpForce = 220f;
    [SerializeField]
    private float _speed = 2.5f;

    private PlayerAnimation _playerAnim;

    private SpriteRenderer _PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
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

        if (move != 0)
        {
            _PlayerSprite.flipX = move < 0;
        }

        _playerAnim.Move(move);
        _rbody.velocity = new Vector2(move * _speed, _rbody.velocity.y);


        if (_rbody.velocity.y == 0)
        {
            _playerAnim.Jump(false);

        }
    }

    void Jump()
    {
        if (_rbody.velocity.y == 0)
        {
            _rbody.AddForce(Vector2.up * _jumpForce);
            _playerAnim.Jump(true);
        }
          

    }

}
