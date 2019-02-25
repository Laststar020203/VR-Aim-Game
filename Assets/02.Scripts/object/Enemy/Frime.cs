using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Frime : Solider
{

    [HideInInspector]
    public bool isDie = false;

    Transform tr;
    Vector3 firstPosition;

    private readonly int count;

    Animator anim;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        firstPosition = tr.position;
        isCompeleted = true;
    }

    private void Start()
    {
        //count = Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1));
        
    }

    private void Update()
    {
       anim.SetBool("IsIdle", isCompeleted);
            


    }

    private IEnumerator Idle(float delay, float duration)
    {
        yield return new WaitForSeconds(delay * count);
       
        tr.DOMove(firstPosition, duration).OnComplete(delegate
        {
            isCompeleted = true;
        });
    }
   
    private IEnumerator Triangle(float delay, float duration , float power)
    {
        
        yield return new WaitForSeconds(delay * Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_") + 1)));


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
}
