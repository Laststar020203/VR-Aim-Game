using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Transform tr;
    public Image bloodScreen;


    public float fireCoolTime;
    public float nextTime;

    
    Transform cameraTr;

    private void Start()
    {
        tr = GetComponent<Transform>();
        bloodScreen.color = Color.clear;
        cameraTr = Camera.main.transform;
    }
    
    void Update()
    {
       if(Time.time > nextTime)
       {
            Fire();

            nextTime = Time.time + fireCoolTime;
       }


       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }


    
    private void Fire()
    {

        var _bullet = GameManager.instance.GetBullet(0);
        
        
        if (_bullet != null)
        {
            _bullet.location = (cameraTr.position + cameraTr.forward) - cameraTr.position;
            _bullet.transform.position = tr.position + tr.forward * 5;
            _bullet.gameObject.SetActive(true);
            _bullet.Fire(2.0f);
        }
    }

    private void Damage()
    {
        StartCoroutine(ShowBloodScreen());
    }

    private IEnumerator ShowBloodScreen()
    {

        bloodScreen.color = new Color(1, 0, 0, Random.Range(0.5f, 0.8f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BULLET"))
        {

            Damage();
        }
    }

}
