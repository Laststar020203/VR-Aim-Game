using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrimeBullet : BulletBase
{
    
    
    
    public override void Fire(float destoryTime)
    {
        transform.rotation = Quaternion.LookRotation(location);
        GetComponent<Rigidbody>().AddForce(location.normalized * speed);

        DestroyBullet(destoryTime);
    }

   





}
