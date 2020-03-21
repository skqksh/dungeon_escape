using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer monsterSprite;


    private Player _player;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        monsterSprite = GetComponentInChildren<SpriteRenderer>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        float distanceFromPlayer = Vector3.Distance(_player.transform.position, transform.position);

        animator.SetBool("InCombat", distanceFromPlayer < 1.2);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetBool("InCombat"))
        {
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        monsterSprite.flipX = currentTarget == pointA.position;

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}