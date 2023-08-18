using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }

    void Awake() => Inst = this;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ElementManager.Inst.SetElement(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ElementManager.Inst.SetElement(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ElementManager.Inst.SetElement(2);
        }

#endif
    }
}
