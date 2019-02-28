using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour, IBulletController
{
    public int score = 0;
    public Text scoreText;

    public Slider healthBar;

    public GameObject playerBullet;
    List<BulletBase> playerBulletPooling = new List<BulletBase>();

    public static MainSceneManager instance;

    public Player player;


    public bool isbossAlive = false;

    public Boss[] bosses;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        CreatePooling(20);
        SetTree();

        EventManager.AddListener<EnemyDeathEvent>(AddScore);


    }

    void Update()
    {

        UpdateUI();

        if (!isbossAlive)
            CreateBoss(0);

    }

    void CreateBoss(int index)
    {
        Instantiate<Boss>(bosses[index], Vector3.zero, Quaternion.identity);
        isbossAlive = true;
    }

    private void SetTree()
    {


        GameObject right = GameObject.Find("RightTrees");
        GameObject left = GameObject.Find("LeftTrees");

        foreach (Tree tree in right.GetComponentsInChildren<Tree>())
        {
            tree.spawn = Tree.Spawn.Right;

        }

        foreach (Tree tree in left.GetComponentsInChildren<Tree>())
        {
            tree.spawn = Tree.Spawn.Left;

        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score : " + score;
        healthBar.value = (float)player.HP / player.MAX_HEALTH;

    }

    public void CreatePooling(int count)
    {
        GameObject playerbullets = new GameObject("PlayerObjectPooling");
        BulletBase clone = playerBullet.GetComponent<BulletBase>();

        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate<BulletBase>(clone, playerbullets.transform);
            obj.gameObject.name = "Player's Bullet_" + i.ToString("00");
            obj.gameObject.SetActive(false);
            playerBulletPooling.Add(obj);
        }
    }

    public BulletBase GetBullet(int index)
    {
        for (int i = 0; i < playerBulletPooling.Count; i++)
        {
            if (playerBulletPooling[i].gameObject.activeSelf == false)
            {
                return playerBulletPooling[i];
            }
        }

        return null;
    }

    private void AddScore(EnemyDeathEvent e)
    {
        score += e.DeathEnemyWorth;
    }
}
