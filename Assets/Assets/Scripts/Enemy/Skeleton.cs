﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

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
}