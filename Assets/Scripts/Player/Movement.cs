using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator m_Animator;
    Rigidbody2D m_Rigidbody2D;
    CollisionHit m_CollisionHit;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_CollisionHit = GetComponent<CollisionHit>();
        SaveManager.Inst.InitPlayerInfo();
    }

    public void SetAnimator()
    {
        m_Animator = transform.GetChild((int)ElementManager.Inst.element).GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_CollisionHit.onGround)
        {
            m_Animator.SetTrigger("jump");
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpPower);
        }

        m_Animator.SetFloat("verticalVelocity", m_Rigidbody2D.velocity.y);
        m_Animator.SetBool("onGround", m_CollisionHit.onGround);
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Rending"))
        {
            m_Rigidbody2D.velocity = Vector2.Lerp(m_Rigidbody2D.velocity, new Vector2(0, m_Rigidbody2D.velocity.y), Time.deltaTime * 6);
            return;
        }
        float x = Input.GetAxis("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(x * speed * Time.deltaTime, m_Rigidbody2D.velocity.y);
        if (x != 0) transform.localScale = new Vector3(x > 0 ? -1 : 1, 1, 1);

        m_Animator.SetBool("isWalk", x != 0);
    }
}
