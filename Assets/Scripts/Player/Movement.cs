using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2D;
    CollisionHit m_CollisionHit;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_CollisionHit = GetComponent<CollisionHit>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_CollisionHit.onGround)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpPower);
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(x * speed * Time.deltaTime, m_Rigidbody2D.velocity.y);
    }
}
