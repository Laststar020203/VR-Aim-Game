using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{

    public override void Fire(float destoryTime)
    {

        transform.rotation = Quaternion.LookRotation(location);
        
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        DestroyBullet(destoryTime);
    }

    




}
