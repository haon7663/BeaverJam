using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField]
    ElementManager elementManager;
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
                    if (elementManager.element == Element.Vapor)
                    {
                        //���ó��
                    }
                    else if (elementManager.element == Element.Water)
                    {
                        //����� ó��
                        elementManager.element = Element.Vapor;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (elementManager.element == Element.Ice)
                    {
                        //����� ó��
                        elementManager.element = Element.Water;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                }
                else if (trapType == TrapType.ice)
                {
                    if (elementManager.element == Element.Vapor)
                    {
                        elementManager.element = Element.Water;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (elementManager.element == Element.Water)
                    {
                        //����� ó��
                        elementManager.element = Element.Ice;
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                    else if (elementManager.element == Element.Ice)
                    {
                        //����� ó��
                        boxCollider2D.enabled = false;
                        runingTime = true;
                    }
                }
            }
        }
    }


}
