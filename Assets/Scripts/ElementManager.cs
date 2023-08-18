using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Vapor, Water, Ice }

public class ElementManager : MonoBehaviour
{
    public static ElementManager Inst { get; private set; }

    public Element element;

    public int elementalCount;
    public int elementalEnergy;

    void Awake() => Inst = this;

    public bool SetElement(int elementCount)
    {
        if (elementCount < 0 || elementCount > 2)
            return false;
        element = (Element)elementCount;
        return true;
    }

    public void ChargeEnergy(int value)
    {
        if (elementalCount >= 3) return;

        elementalEnergy += value;
        if (elementalEnergy >= 6)
        {
            elementalCount++;
            var overCharger = elementalEnergy - 6;
            elementalEnergy = overCharger;
            if (elementalCount >= 3) elementalEnergy = 0;
        }
    }

    public void DecreaseEnergy()
    {
        elementalCount--;
    }
}
