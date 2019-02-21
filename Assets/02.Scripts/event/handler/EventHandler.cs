using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public delegate void GameEvent<T>(T t) where T : Event;

public class EventHandler : MonoBehaviour
{
    public static void AddEvent<T>(GameEvent<T> dele)
          where T : Event
    {
        object listeners = typeof(T).GetProperty("Listeners").GetValue(null , null);

        listeners = dele;
    }


    public static void CallEvent<T>(T e)
        where T : Event
    {
        FieldInfo field = typeof(T).GetField("listeners");


        List<GameEvent<T>> list = (List<GameEvent<T>>)field.GetValue(null);

        foreach (GameEvent<T> listeners in list)
        {
            listeners(e);
        }
    }
}
