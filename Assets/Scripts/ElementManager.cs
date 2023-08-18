using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Vapor, Water, Ice }

public class ElementManager : MonoBehaviour
{
    public static ElementManager Inst { get; private set; }

    public Element element;

    public float elementalEnergy;

    void Awake() => Inst = this;

    public bool SetElement(int elementCount)
    {
        if (elementCount < 0 || elementCount > 2)
            return false;
        element = (Element)elementCount;
        return true;
    }

    public void ChargeEnergy(float value)
    {
        elementalEnergy += value;
        if (elementalEnergy > 100) elementalEnergy = 100;
    }

    public void ZeroEnergy()
    {
        elementalEnergy = 0;
    }
}
