using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;

public class Frime : Solider
{

    [HideInInspector]
    public bool isDie = false;

    Transform tr;
    public Vector3 firstPosition;

    Animator anim;

    private int count
    {
        get
        {
            return Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1));
        }
    }

    public override string NAME { get { return name; } set { name = value; } }

    public override int HP { get { return hp; } set { hp = value; } }
    public override int WORTH { get { return worth; } set { worth = value; } }
    public override float FIRE_COOL_TIME { get { return fireCoolTime; } set { fireCoolTime = value; } }

    public GameObject bullet;

    private Transform playerTr;

    Sequence triangle;

    private bool firstMoving = true;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        firstPosition = tr.position;

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();

    }

    private void Start()
    {

        isCompeleted = false;
        StartCoroutine(Idle(0.1f, 0.5f));
        //count = Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1));
        name = this.gameObject.name;
    }

    private void Update()
    {
       //Animation
       anim.SetBool("IsIdle", isCompeleted);
       
      //Look
       tr.LookAt(playerTr);
    
       if(Time.time > fireTimeNextTime)
       {
            BeamAttack();
            fireTimeNextTime = Time.time + FIRE_COOL_TIME;
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


        triangle = DOTween.Sequence();
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
        EventManager.CallEvent(new EnemyDeathEvent(this));
        Destroy(this.gameObject);
    }

    
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER_BULLET"))
        {
            Damage(coll.contacts[0].point);
        }
    }

    protected override void Damage(Vector3 hitPoint)
    {
        Destroy(Instantiate(damageParticle, hitPoint, Quaternion.identity), 5.0f);
        HP -= 10;
        if(HP <= 0)
        {
            Death();
        }
    }

    private void OnDisable()
    {
        triangle.Kill();
    }

}
//ontrigger는 충돌의 위치를 찾을 수 없음