using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 buttomOffset, topOffset, rightOffset, leftOffset;
    [SerializeField] float radious;

    public bool onGround, onWall;

    void Update()
    {
        onGround = Physics2D.OverlapCircle(transform.position + buttomOffset, radious, groundLayer);
        onWall = Physics2D.OverlapCircle(transform.position + leftOffset, radious, groundLayer) ||
                 Physics2D.OverlapCircle(transform.position + rightOffset, radious, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + buttomOffset, radious);
        Gizmos.DrawWireSphere(transform.position + leftOffset, radious);
        Gizmos.DrawWireSphere(transform.position + rightOffset, radious);
    }
}
