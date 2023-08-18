using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Element { Vapor, Water, Ice }

public class ElementManager : MonoBehaviour
{
    public static ElementManager Inst { get; private set; }

    [SerializeField] Element element;

    void Awake() => Inst = this;

    public void SetElement(int elementCount)
    {
        element = (Element)elementCount;
    }
}
