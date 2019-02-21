using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;



public class CollectObjectHitEvent : Event
{
    private static List<GameEvent<CollectObjectHitEvent>> listeners = new List<GameEvent<CollectObjectHitEvent>>();

    public override object Listeners
    {
        get
        {
            return listeners;
        }

        set
        {
            GameEvent<CollectObjectHitEvent> listener = (GameEvent<CollectObjectHitEvent>)value;

            listeners.Add(listener);
        }
    }

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
