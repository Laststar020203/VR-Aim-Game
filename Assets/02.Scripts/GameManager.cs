using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{





    private void Awake()
    {
       

    }

    // Start is called before the first frame update
    void Start()
    {
        SetTree();

        
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetTree()
    {
        GameObject right = GameObject.Find("RightTrees");
        GameObject left = GameObject.Find("LeftTrees");

        foreach(Tree tree in right.GetComponentsInChildren<Tree>())
        {
            tree.spawn = Tree.Spawn.Right;
       
        }

        foreach (Tree tree in left.GetComponentsInChildren<Tree>())
        {
            tree.spawn = Tree.Spawn.Left;
            
        }
    }
}
