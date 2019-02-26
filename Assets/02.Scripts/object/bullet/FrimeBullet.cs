using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrimeBullet : MonoBehaviour
{
    public float speed;
    public Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(location);
        GetComponent<Rigidbody>().AddForce(location.normalized  * speed * Time.deltaTime);
      
    }
}
