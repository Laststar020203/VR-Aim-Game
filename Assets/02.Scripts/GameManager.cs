using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public Text scoreText;

    private void Awake()
    {
       

    }

    // Start is called before the first frame update
    void Start()
    {
        SetTree();

        EventManager.AddListener<CollectObjectHitEvent>(AddScore);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
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

    private void AddScore(CollectObjectHitEvent e)
    {
        Debug.Log(e.TargetScore);
        score += e.TargetScore;

    }

    private void UpdateUI()
    {
        scoreText.text = "Score : " + score;
    }
}
