using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlideTrap : MonoBehaviour
{
    public float colTime;
    public float curTime;
    private bool isDrop;
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        isDrop = false;
        curTime = colTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrop)
        {
            curTime -= Time.deltaTime; 
            if(curTime < 0)
            {
               isDrop = false;
               curTime = colTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDrop)
        {
            if (collision.gameObject.tag == "Player")
            {
                isDrop = true;
                Instantiate(rock, transform.position, transform.rotation);
            }
        }
    }
}
