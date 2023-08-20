using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Rock : MonoBehaviour
{
    AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(this.gameObject, 0.7f);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Death.Inst.CallDeath();
            audios.Play();
            Destroy(this.gameObject, 0.7f);
        }
    }
}
