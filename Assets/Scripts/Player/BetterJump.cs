using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private Rigidbody2D RB;

    [SerializeField] float fallMultiplier;
    [SerializeField] float lowJumpMultiplier;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (RB.velocity.y < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (RB.velocity.y > 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
