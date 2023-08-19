using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator m_Animator;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        m_Animator.SetTrigger("fadeIn");
    }
    public void FadeOut()
    {
        m_Animator.SetTrigger("fadeOut");
    }
}
