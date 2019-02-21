
using System.Collections.Generic;
using UnityEngine;




public class CollectObjectHitEvent : Event
{
    public static readonly List<GameEvent<CollectObjectHitEvent>> listeners = new List<GameEvent<CollectObjectHitEvent>>();

    

    private Vector3 hitPoint;
    

    public CollectObjectHitEvent(Vector3 hitPoint)
    {
       
        this.hitPoint = hitPoint;
    }

    public Vector3 HitPoint
    {
        get
        {
            return hitPoint;
        }
    }

    
    


}
