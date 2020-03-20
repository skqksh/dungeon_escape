﻿using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage(1);
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}