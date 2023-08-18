using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{ 
    public static UIManager Inst { get; private set; }

    [Header("Element Image")]
    [SerializeField] Image[] elementalGaugeFillImage;
    [SerializeField] Image elementStateImage;
    [SerializeField] TMP_Text elementCountText;

    [SerializeField] Sprite[] elementStateSprites;
    

    void Awake() => Inst = this;

    private void Update()
    {
        //elementStateImage.sprite = elementStateSprites[Elemental.saveElement];

        int count = ElementManager.Inst.elementalCount;

        for (int i = 0; i < 6; i++)
            elementalGaugeFillImage[i].enabled = i < ElementManager.Inst.elementalEnergy;
        elementCountText.text = count == 0 ? "" : count.ToString();

    }
}
