using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{ 
    public static UIManager Inst { get; private set; }

    [SerializeField] Elemental elemental;

    [Header("Element Image")]
    [SerializeField] RectTransform[] elementalGauge;
    [SerializeField] RectTransform elementRect;
    [SerializeField] TMP_Text elementCountText;

    [SerializeField] Sprite[] elementStateSprites;
    

    void Awake() => Inst = this;

    private void Update()
    {
        //elementStateImage.sprite = elementStateSprites[Elemental.saveElement];

        int count = ElementManager.Inst.elementalCount;
        if (elemental.isChange)
        {
            SettingManager.Inst.SetTimeScale(0.1f);
            elementRect.localPosition = Vector3.Lerp(elementRect.localPosition, new Vector3(-630, 420), Time.deltaTime * 100);
            for (int i = 0; i < 3; i++)
            {
                Color color = Color.white;
                var elementCount = Elemental.saveElement;
                var distance = elementCount == i ? 0 : elementCount > i ? elementCount - i : i - elementCount;
                var mDistance = i - elementCount;
                if (distance == 0)
                    elementalGauge[i].SetAsLastSibling();
                else
                    elementalGauge[i].SetAsFirstSibling();


                Vector3 localSave = new Vector3(mDistance * 100, 0);
                elementalGauge[i].localPosition = Vector3.Lerp(elementalGauge[i].localPosition, localSave, Time.deltaTime * 75);
                elementalGauge[i].sizeDelta = Vector3.Lerp(elementalGauge[i].sizeDelta, new Vector3(83.72f / (1 + (float)distance / 2), 206.4f / (1 + (float)distance / 2)), Time.deltaTime * 75);

                for (int j = 0; j < 6; j++)
                {
                    color.a = distance == 0 ? 1 : distance == 1 ? 0.2f : 0f;
                    var imageColor = elementalGauge[i].transform.GetChild(j).GetComponent<Image>().color;

                    imageColor = Color.Lerp(imageColor, color, Time.deltaTime * 60);

                    elementalGauge[i].transform.GetChild(j).GetComponent<Image>().color = imageColor;
                    elementalGauge[i].transform.GetChild(j).GetChild(0).GetComponent<Image>().color = imageColor;
                }
            }
        }
        else
        {
            elementRect.localPosition = Vector3.Lerp(elementRect.localPosition, new Vector3(-730, 410), Time.deltaTime * 10);
            for (int i = 0; i < 3; i++)
            {
                Color color = Color.white;
                var elementCount = Elemental.saveElement;
                var distance = elementCount == i ? 0 : elementCount > i ? elementCount - i : i - elementCount;

                for (int j = 0; j < 6; j++)
                {
                    color.a = distance == 0 ? 1 : 0f;
                    var imageColor = elementalGauge[i].transform.GetChild(j).GetComponent<Image>().color;

                    imageColor = Color.Lerp(imageColor, color, Time.deltaTime * 60);

                    elementalGauge[i].transform.GetChild(j).GetComponent<Image>().color = imageColor;
                    elementalGauge[i].transform.GetChild(j).GetChild(0).GetComponent<Image>().color = imageColor;
                }
            }
        }
        elementCountText.text = count == 0 ? "" : count.ToString();
    }
}
