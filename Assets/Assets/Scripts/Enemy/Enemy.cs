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
    protected float attackRange = 1.2f;

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
        Combat();
            
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            || animator.GetBool("InCombat"))
        {
            return;
        }

        Movement();
    }

    public virtual void Combat()
    {
    
        float distanceFromPlayer = Vector3.Distance(_player.transform.position, transform.position);
        bool inCombat = distanceFromPlayer < attackRange;
        animator.SetBool("InCombat", inCombat);
        if (inCombat)
        {
            Vector3 direction = _player.transform.position - transform.position;
            monsterSprite.flipX = direction.x < 0;
        }
        
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