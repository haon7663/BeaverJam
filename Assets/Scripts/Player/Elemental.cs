using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    public static int saveElement;

    public bool isChange;
    bool isWUp = true;
    [SerializeField] Fade fade;
    public GameObject[] ElemetalBody;

    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            ElemetalBody[i].SetActive(i == (int)ElementManager.Inst.element);
        }
        if (isChange || ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.W)) && ElementManager.Inst.elementalEnergy >= 6))
        {
            if (!isChange)
            {
                if(Input.GetKeyDown(KeyCode.W)) isWUp = false;
                isChange = true;
                SettingManager.Inst.SetTimeScale(0.1f);
                fade.FadeIn();
            }
            else
            {
                saveElement += (Input.GetKeyDown(KeyCode.Q) ? -1 : Input.GetKeyDown(KeyCode.E) ? 1 : 0);
                if (saveElement > 2) saveElement = 0;
                else if (saveElement < 0) saveElement = 2;

                if (Input.GetKeyUp(KeyCode.W))
                    isWUp = true;
            }

            if (Input.GetKeyDown(KeyCode.W) && isWUp)
            {
                if((int)ElementManager.Inst.element == saveElement)
                {
                    SettingManager.Inst.SetTimeScale(1f);
                    fade.FadeOut();
                    isChange = false;
                }
                else
                {
                    var isReturn = ElementManager.Inst.SetElement(saveElement);
                    if (isReturn)
                    {
                        SettingManager.Inst.SetTimeScale(1f);
                        fade.FadeOut();
                        isChange = false;

                        ElementManager.Inst.DecreaseEnergy();
                    }
                }
            }
        }
    }
}
