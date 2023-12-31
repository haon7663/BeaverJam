using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    public GameObject particleBundle;
    private float curTime;
    private bool runingTime;
    // Start is called before the first frame update
    void Start()
    {
        curTime = 2f;
        runingTime = true;
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runingTime)
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            particleBundle.SetActive(true);
            curTime -= Time.deltaTime;
            if(curTime < 0)
            {
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                particleBundle.SetActive(false);
                runingTime = false;
                curTime = 1.5f;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
            if (curTime < 0)
            {
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
                particleBundle.SetActive(true);
                runingTime = true;
                curTime = 2f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ElementManager.Inst.SetElement((int)ElementManager.Inst.element + 1);
        }
    }
}
