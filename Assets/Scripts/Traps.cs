using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public enum TrapType { fire, ice }
    public TrapType trapType;
    private BoxCollider2D boxCollider2D;
    public float coolTime;
    private float curTime;
    private bool runingTime;
    // Start is called before the first frame update
    void Start()
    {
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
                if (trapType == TrapType.fire)
                {
                    if (ElementManager.Inst.element == Element.Vapor)
                    {
                        //사망처리
                    }
                    else if (ElementManager.Inst.element == Element.Water)
                    {
                        //대미지 처리
                        ElementManager.Inst.element = Element.Vapor;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (ElementManager.Inst.element == Element.Ice)
                    {
                        //대미지 처리
                        ElementManager.Inst.element = Element.Water;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                }
                else if (trapType == TrapType.ice)
                {
                    if (ElementManager.Inst.element == Element.Vapor)
                    {
                        ElementManager.Inst.element = Element.Water;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (ElementManager.Inst.element == Element.Water)
                    {
                        //대미지 처리
                        ElementManager.Inst.element = Element.Ice;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (ElementManager.Inst.element == Element.Ice)
                    {
                        //대미지 처리
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                }
            }
        }
    }


}
