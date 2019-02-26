using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BulletBase : MonoBehaviour
{
    public Vector3 location { get; set; }
    public float speed;

   private IEnumerator DestroyingBullet(float time)
   {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
   }

   public void DestroyBullet(float time)
   {
        StartCoroutine(DestroyingBullet(time));
   }

    public abstract void Fire(float destoryTime);
   
}
