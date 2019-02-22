using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss : MonoBehaviour
{
    public List<Solider> soilders;

    protected abstract void SpawnMySoilder();

    protected abstract void Order();

    protected bool isSolidersCompelete()
    {
        bool check = false;
        foreach(Solider solider in soilders)
        {
            check = solider.isCompeleted;
        }
        return check;
    }
}
