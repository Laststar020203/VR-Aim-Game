using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Transform tr;
   
   

    #region PlayerFire
    PlayerFire playerFire;
    public GameObject bullet;
    public float fireCoolTime;
    private float nextTime;
    #endregion


    #region PlayerDamage
    PlayerDamage playerDamage;
    public Image bloodScreen;
    #endregion


    void onEnable()
    {
        playerFire = new PlayerFire(this);
        playerDamage = new PlayerDamage(this);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 2f);
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BULLET"))
        {
            playerDamage.Damage();
        }
    }
}
