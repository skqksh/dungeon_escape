﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();
        this.Health = health;
    }

    public void Damage(int damageAmount)
    {
        animator.SetTrigger("Hit");
        --Health;
        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            Destroy(this.gameObject,5.0f);
        }

    }

    public override void Combat()
    {
        base.Combat();
        if (animator.GetBool("InCombat"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}