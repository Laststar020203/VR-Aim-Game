using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public abstract class Solider : MonoBehaviour
{
    public abstract void Play(int delay, int duration , int power);
    public bool isCompeleted = false;
    

}
