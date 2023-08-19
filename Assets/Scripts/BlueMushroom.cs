using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMushroom : MonoBehaviour
{
    private CapsuleCollider2D _capsuleCollider2D;

    private void Awake()
    {
        _capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player") return;
        SaveManager.Inst.SavePlayerInfo(col.transform.position);
        print(col.transform.position);
        gameObject.SetActive(false);
    }
}
