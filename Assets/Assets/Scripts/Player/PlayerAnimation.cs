using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArcAnim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArcAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Math.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        _anim.SetBool("Jumping", isJumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordArcAnim.SetTrigger("SwordAnimation");
    }
}
