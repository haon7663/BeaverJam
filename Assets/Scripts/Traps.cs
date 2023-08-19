using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    public float coolTime;
    private float curTime;
    private bool runingTime;
    // Start is called before the first frame update
    void Start()
    {
        curTime = coolTime;
        runingTime = false;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runingTime)
        {
            curTime -= Time.deltaTime;
            if (curTime < 0)
            {
                runingTime = false;
                curTime = coolTime;
                boxCollider2D.enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!runingTime)
            {

                if (ElementManager.Inst.element == Element.Vapor)
                {
                    Death.Inst.CallDeath();
                }
                else if (ElementManager.Inst.element == Element.Water)
                {
                    ElementManager.Inst.SetElement(0);
                    boxCollider2D.enabled = false;
                    runingTime = true;
                }
                else if (ElementManager.Inst.element == Element.Ice)
                {
                    ElementManager.Inst.SetElement(1);
                    boxCollider2D.enabled = false;
                    runingTime = true;
                }

            }
        }
    }
}
