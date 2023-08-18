using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    [HideInInspector] public int saveElement;

    bool isChange;

    void Update()
    {
        if (isChange || ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && ElementManager.Inst.elementalEnergy >= 100))
        {
            isChange = true;
            saveElement += (Input.GetKeyDown(KeyCode.Q) ? -1 : Input.GetKeyDown(KeyCode.E) ? 1 : 0);
            if (saveElement > 2) saveElement = 0;
            else if (saveElement < 0) saveElement = 2;

            if (Input.GetKeyDown(KeyCode.W))
            {
                if((int)ElementManager.Inst.element == saveElement)
                {
                    isChange = false;
                }
                else
                {
                    var isReturn = ElementManager.Inst.SetElement(saveElement);
                    if (isReturn)
                    {
                        isChange = false;
                        ElementManager.Inst.ZeroEnergy();
                    }
                }
            }
        }
    }
}
