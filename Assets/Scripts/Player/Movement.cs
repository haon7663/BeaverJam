using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    CollisionHit collisionHit;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collisionHit = GetComponent<CollisionHit>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collisionHit.onGround)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(x * speed * Time.deltaTime, rigidbody2D.velocity.y);
    }
}
