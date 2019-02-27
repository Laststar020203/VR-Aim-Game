using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEvent : EntityDeathEvent
{
    public static readonly List<GameEvent<EnemyDeathEvent>> listeners = new List<GameEvent<EnemyDeathEvent>>();

    private readonly int deathEnemyWorth;
    public int DeathEnemyWorth { get { return deathEnemyWorth; }}

    private readonly Enemy deathEnemy;
    public Enemy DeathEnemy { get { return deathEnemy; } }

    public EnemyDeathEvent(Enemy enemy) : base(enemy)
    {
        this.deathEnemyWorth = enemy.WORTH;
        this.deathEnemy = enemy;
    }
}
