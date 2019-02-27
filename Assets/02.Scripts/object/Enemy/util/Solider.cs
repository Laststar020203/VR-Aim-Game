using System.Collections.Generic;
using UnityEngine;


public abstract class Solider : MonoBehaviour
{
    public abstract void Play(float delay, float duration , float power);
    
    public bool isCompeleted = true;

    public float coolTime;
    protected float nextTime;

    protected int myScore;

    public GameObject damageParticle;

    public abstract void Death();
    public abstract void Damage(Vector3 hitPoint);

}
