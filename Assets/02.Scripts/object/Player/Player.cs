﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Transform tr;

   
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
       
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

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
