using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss : MonoBehaviour , IBulletController
{
    public List<Solider> soilders = new List<Solider>();

    protected Queue pattern = new Queue();
   //List로 순화하는 형식으로 안하고 Queue로 한 이유는 상황에 따라 패턴을 바꿔야 할 때
    public bool isDie = false;

    public GameObject frimeBullet;

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

    public void CreatePooling(int count)
    {
        foreach (Solider solider in soilders)
        {

            string name = solider.gameObject.name;
            List<BulletBase> bullets = new List<BulletBase>();
            BulletBase clone = frimeBullet.GetComponent<BulletBase>();

            GameObject objectPools = new GameObject(name + "'s ObjectPools");

            for (int i = 0; i < count; i++)
            {
                var obj = Instantiate<BulletBase>(clone, objectPools.transform);
                obj.gameObject.name = name + "'s Bullet_" + i.ToString("00");
                obj.gameObject.SetActive(false);
                bullets.Add(obj);
            }

            frimeBulletPool.Add(bullets);
        }
    }

    
    public BulletBase GetBullet(int index)
    {
        List<BulletBase> bulletList = frimeBulletPool[index];
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (bulletList[i].gameObject.activeSelf == false)
            {
                return bulletList[i];
            }
        }

        return null;
    }
    

    protected List<List<BulletBase>> frimeBulletPool = new List<List<BulletBase>>();
    

   
}
