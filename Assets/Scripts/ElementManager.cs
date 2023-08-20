using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Vapor, Water, Ice }

public class ElementManager : MonoBehaviour
{
    public static ElementManager Inst { get; private set; }

    [SerializeField] GameObject player;
    public Element element;

    public int elementalEnergy;

    void Awake() => Inst = this;

    public bool SetElement(int elementCount)
    {
        if (elementCount < 0 || elementCount > 2)
            return false;
        element = (Element)elementCount;
        Elemental.saveElement = elementCount;

        player.GetComponent<Movement>().SetAnimator();
        player.layer = 10 + elementCount;
        UIManager.Inst.ChangeElement();
        return true;
    }

    public void ChargeEnergy(int value)
    {
        if (elementalEnergy >= 6)
            return;

        elementalEnergy += value;
        UIManager.Inst.ChangeElement();
    }

    public void DecreaseEnergy()
    {
        elementalEnergy = 0;
        UIManager.Inst.ChangeElement();
    }
}
