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

    private int count;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        firstPosition = tr.position;

        count = Convert.ToInt32(this.gameObject.name.Substring(this.gameObject.name.IndexOf("_")));
    }

    private void Start()
    {
       
    }

   
    private IEnumerator Idle(int delay, int duration)
    {
        yield return new WaitForSeconds(delay * count);
        tr.DOMove(firstPosition, duration).OnComplete(delegate
        {
            isCompeleted = true;
        });
    }

    private IEnumerator Triangle(int delay, int duration , int power)
    {
        yield return new WaitForSeconds(delay * count);
        tr.DOMove(new Vector3(tr.position.x + power, tr.position.y + power, tr.position.z), duration).OnComplete(delegate
        {
            tr.DOMove(new Vector3(tr.position.x - power * 2, tr.position.y, tr.position.z), duration).OnComplete(delegate
           {
               tr.DOMove(firstPosition, duration).OnComplete(delegate
               {
                   isCompeleted = true;
               });
           });

        });
    }

    public override void Play(int delay, int duration , int power)
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
