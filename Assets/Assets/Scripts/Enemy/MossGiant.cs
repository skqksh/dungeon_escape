using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    private Vector3 _currentTarget;
    private Animator _animator;
    private SpriteRenderer _monsterSprite;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        
        _monsterSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Attack()
    {

    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        
        Movement();
    }

    private void Movement()
    {
        _monsterSprite.flipX = _currentTarget == pointA.position;
        
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _animator.SetTrigger("Idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}
