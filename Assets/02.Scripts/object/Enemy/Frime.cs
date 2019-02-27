using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Frime : Solider , IGvrPointerHoverHandler
{

    [HideInInspector]
    public bool isDie = false;

    Transform tr;
    public Vector3 firstPosition;

    public float hp;
    

    Animator anim;

    private int count
    {
        get
        {
            return Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1));
        }
    }
    public GameObject bullet;

    private Transform playerTr;

    private bool firstMoving = true;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        firstPosition = tr.position;

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();

        coolTime = 0.1f;

        myScore = 20;
    }

    private void Start()
    {

        isCompeleted = false;
        StartCoroutine(Idle(0.1f, 0.5f));
        //count = Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1));

    }

    private void Update()
    {
       //Animation
       anim.SetBool("IsIdle", isCompeleted);
       
      //Look
       tr.LookAt(playerTr);
    
       if(Time.time > nextTime)
       {
            BeamAttack();
            nextTime = Time.time + coolTime;
       }


    }

    private IEnumerator Idle(float delay, float duration)
    {
        yield return new WaitForSeconds(delay * count);
       
        tr.DOMove(firstPosition, duration).OnComplete(delegate
        {
            isCompeleted = true;
            firstMoving = false;
        });
    }
   
    private IEnumerator Triangle(float delay, float duration , float power)
    {
        
        yield return new WaitForSeconds(delay * count);


        Sequence triangle = DOTween.Sequence();
        triangle.Append(tr.DOMove(new Vector3(tr.position.x + power, tr.position.y + power, tr.position.z), duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x - power * 2, tr.position.y, tr.position.z), duration));
        triangle.Append(tr.DOMove(firstPosition, duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x - power, tr.position.y - power, tr.position.z), duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x + power * 2, tr.position.y, tr.position.z), duration));
        triangle.Append(tr.DOMove(firstPosition, duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x + power, tr.position.y + power, tr.position.z), duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x - power * 2, tr.position.y, tr.position.z), duration));
        triangle.Append(tr.DOMove(firstPosition, duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x - power, tr.position.y - power, tr.position.z), duration));
        triangle.Append(tr.DOMove(new Vector3(tr.position.x + power * 2, tr.position.y, tr.position.z), duration));
        triangle.Append(tr.DOMove(firstPosition, duration).OnComplete(delegate
        {
            isCompeleted = true;
        }));
        //triangle.Play();
    }

    public override void Play(float delay, float duration , float power)
    {
        isCompeleted = false;
       
        FrimeController.State state = FrimeController.state;
        switch (state)
        {
            case FrimeController.State.IDLE:
                StartCoroutine(Idle(delay, duration));
                break;
            case FrimeController.State.TRIANGLE:
                StartCoroutine(Triangle(delay, duration , power));
                break;
        }
    }

    private void BeamAttack()
    {
        if (firstMoving) return;
        /*
        GameObject _bullet = Instantiate(bullet, tr.position, Quaternion.identity);
        FrimeBullet fb = _bullet.GetComponent<FrimeBullet>();
        fb.location =  playerTr.position - tr.position + new Vector3(0, 4 ,0 );
        Destroy(_bullet, 3.0f);
        */
        var _bullet = FrimeController.head.GetBullet(count - 1);
        if(_bullet != null)
        {
            _bullet.location = (playerTr.position + new Vector3(0, 0f, 0)) - tr.position;
            _bullet.transform.position = tr.position;
            _bullet.gameObject.SetActive(true);
            _bullet.Fire(5.0f);
        }
    }

    float rayTimeNext = 0;
    float rayCoolTime = 0.1f;

   
    
    public override void Death()
    {
        Debug.Log(this.gameObject.name + " heart!");
    }

    
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER_BULLET"))
        {
            Damage(coll.contacts[0].point);
        }
    }

    public override void Damage(Vector3 hitPoint)
    {
        
    }
}
//ontrigger는 충돌의 위치를 찾을 수 없음