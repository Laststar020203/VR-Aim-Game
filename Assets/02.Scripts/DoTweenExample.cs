using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenExample : MonoBehaviour
{

    Transform tr;
    [HideInInspector]
    public float number = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        Sequence mySequence = DOTween.Sequence();


        mySequence.PrependInterval(number);
        mySequence.Append(transform.DOMove(new Vector3(tr.position.x + 20, tr.position.y - 20, tr.position.z ), 3f).SetLoops(2, LoopType.Yoyo).OnComplete(delegate
        {
            Debug.Log(gameObject.name);
        }));



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
