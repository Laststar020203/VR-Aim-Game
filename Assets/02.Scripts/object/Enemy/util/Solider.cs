using System.Collections.Generic;
using UnityEngine;


public abstract class Solider : MonoBehaviour, Enemy
{
    public abstract void Play(float delay, float duration , float power);
    
    public bool isCompeleted = true;

    protected float fireTimeNextTime;

    public GameObject damageParticle;

   
    protected abstract void Damage(Vector3 hitPoint);
    public abstract void Death();

    [SerializeField]
    protected int worth;
    [SerializeField]
    protected float fireCoolTime;
    [SerializeField]
    protected int hp;
    protected string name;

    public abstract int WORTH { get; set; }
    public abstract string NAME { get; set; }
    public abstract int HP { get; set;  }
    public abstract float FIRE_COOL_TIME { get; set; }
}
