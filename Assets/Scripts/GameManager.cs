using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }

    bool test;

    void Awake() => Inst = this;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            test = ElementManager.Inst.SetElement(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            test = ElementManager.Inst.SetElement(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            test = ElementManager.Inst.SetElement(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ElementManager.Inst.ChargeEnergy(4);
        }

#endif
    }
}
