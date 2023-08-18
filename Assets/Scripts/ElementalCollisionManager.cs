using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalCollisionManager: MonoBehaviour
{

    [SerializeField]
    ElementManager elementManager;
    public enum ElementBlock {VaporBLock,WaterBLock,IceBLock }
    public ElementBlock elementBlcok;
    private int playerLayer,vaporObstacleLayer, waterObstacleLayer,iceObstacleLayer;
    // Start is called before the first frame update
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        vaporObstacleLayer = LayerMask.NameToLayer("VaporObstacle");
        waterObstacleLayer = LayerMask.NameToLayer("WaterObstacle");
        iceObstacleLayer = LayerMask.NameToLayer("IceObstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if(elementManager.element == Element.Ice )
        {
            Physics2D.IgnoreLayerCollision(playerLayer, iceObstacleLayer, false);
        }
    }
}
