using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    public static UIManager Inst { get; private set; }

    [Header("Element Image")]
    [SerializeField] private Image elementalGaugeFillImage;
    [SerializeField] private Image elementStateImage;

    [SerializeField] private Sprite[] elementStateSprites;
    

    void Awake() => Inst = this;

    private void Update()
    {
        elementalGaugeFillImage.fillAmount = ElementManager.Inst.elementalEnergy / 100f;
        elementStateImage.sprite = elementStateSprites[(int)ElementManager.Inst.element];
    }
}
