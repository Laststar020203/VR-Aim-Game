
using System.Collections.Generic;
using UnityEngine;




public class CollectObjectHitEvent : Event
{
    public static readonly List<GameEvent<CollectObjectHitEvent>> listeners = new List<GameEvent<CollectObjectHitEvent>>();



    private int targetScore = 0;
    

    public CollectObjectHitEvent(Vector3 hitPoint)
    {

        this.targetScore = targetScore;
    }

    public int TargetScore
    {
        get
        {
            return targetScore;
        }
        set
        {
            targetScore = value;
        }
    }

    
    


}
