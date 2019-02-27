using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeathEvent : Event
{
    public static readonly List<GameEvent<EnemyDeathEvent>> listeners = new List<GameEvent<EnemyDeathEvent>>();

    private readonly string deathEntityName;

    public string EntityName { get { return deathEntityName; }}

    public EntityDeathEvent(Entity entitiy)
    {
        this.deathEntityName = entitiy.NAME;    
    }


}
