using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss : MonoBehaviour
{
    public List<Solider> soilders = new List<Solider>();

    protected Queue pattern = new Queue();
   //List로 순화하는 형식으로 안하고 Queue로 한 이유는 상황에 따라 패턴을 바꿔야 할 때
    public bool isDie = false;

    protected abstract void SpawnMySoilder();

    protected abstract string SoilderName { get; }

    protected abstract void SetPattern();

    protected abstract IEnumerator Play(); //제네릭 때매..

    protected bool isSolidersCompelete()
    {
        bool check = false;
        foreach(Solider solider in soilders)
        {
            check = solider.isCompeleted;
            if (!check) return false;
        }
        return check;
    }

    protected string MakeSoilderName(String name, int count) { return name+"_"+count;}

    protected void Order(float delay, float duration, float power)
    {
        foreach(Solider solider in soilders)
        {
            solider.Play(delay, duration, power);
        }
    }
   
}
