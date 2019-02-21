using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{

    public GvrPointerPhysicsRaycaster gpph;
    private RaycastHit[] hits;


    private void Awake()
    {
        this.hits = gpph.hits;
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckHitObject()
    {
        if (hits[0].collider.CompareTag("TARGET"))
        {
            EventHandler.CallEvent(new CollectObjectHitEvent(hits[0].point));
        }
    }
}
