using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask rockSlideLayer;
    [SerializeField] Vector3 buttomOffset, topOffset, rightOffset, leftOffset;
    [SerializeField] float radious;

    public bool onGround, onWall, onHead;

    void Update()
    {
        onGround = Physics2D.OverlapCircle(transform.position + buttomOffset, radious, groundLayer);
        onWall = Physics2D.OverlapCircle(transform.position + leftOffset, radious, groundLayer) ||
                 Physics2D.OverlapCircle(transform.position + rightOffset, radious, groundLayer);
        onHead = Physics2D.OverlapCircle(transform.position + topOffset, radious, rockSlideLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + buttomOffset, radious);
        Gizmos.DrawWireSphere(transform.position + leftOffset, radious);
        Gizmos.DrawWireSphere(transform.position + rightOffset, radious);
        Gizmos.DrawWireSphere(transform.position + topOffset, radious);
    }
}
