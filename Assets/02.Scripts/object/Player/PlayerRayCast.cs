using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{

    public GvrPointerPhysicsRaycaster gpph;
    private RaycastHit[] hits;

    public float coolTime = 1f;
    private float nextTime;

    private int count = 0;

    Transform tr;
    RaycastHit hit;

    private void Awake()
    {
    }

    void Start()
    {
        tr = GetComponent<Transform>();
    }


        // Update is called once per frame
     void Update()
     {
            this.hits = gpph.hits;

            if (Physics.Raycast(tr.position, tr.forward, out hit, Mathf.Infinity))
            {
            Debug.DrawRay(tr.position, tr.forward, Color.blue, Mathf.Infinity);
            if (hit.collider.CompareTag("TARGET"))
            {
                if (Time.time >= nextTime)
                {
                    Debug.Log(Time.time);
                    CheckHitObject();
                    nextTime = Time.time + coolTime;
                }
            }
            }

        }

    

    private void CheckHitObject()
    {
       
            EventManager.CallEvent(new CollectObjectHitEvent(hits[0].point));
        
    }
}
