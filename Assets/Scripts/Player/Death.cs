using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static Death Inst;
    Animator m_Animator;
    Movement m_Movement;
    Elemental m_Elemental;
    Rigidbody2D m_Rigidbody2D;


    void Start()
    {
        Inst = this;
        m_Animator = GetComponent<Animator>();
        m_Movement = GetComponent<Movement>();
        m_Elemental = GetComponent<Elemental>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CallDeath()
    {
        m_Movement.m_Animator.SetBool("isDeath", true);
        m_Movement.m_Animator.SetTrigger("death");
        m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
        m_Movement.enabled = false;
        m_Elemental.enabled = false;
    }
}
