using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tree : MonoBehaviour
{
    Transform tr;
    public float moveSpeed = 10;

    Vector3 startPos;

    public enum Spawn { Right, Left };
    public Spawn spawn;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if(tr.position.z <= -90)
        {
            Respawn();
        }
        
    }

  

    private void Move()
    {
        tr.Translate(Vector3.back * moveSpeed * Time.deltaTime);
       
    }

    private void Respawn()
    {
        switch (spawn)
        {
            case Spawn.Right:
                tr.position = new Vector3(11, 0, 180);
                break;
            case Spawn.Left:
                tr.position = new Vector3(-11, 0, 180);
                break;
        }
       
    }
}
