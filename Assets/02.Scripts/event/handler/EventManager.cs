using System.Collections.Generic;
using System.Reflection;

public delegate void GameEvent<T>(T t) where T : Event;

public class EventManager 
{
    public static void AddListener<T>(GameEvent<T> dele)
          where T : Event
    {
        FieldInfo field = typeof(T).GetField("listeners");

        
        List<GameEvent<T>> list = (List<GameEvent<T>>)field.GetValue(null);

        list.Add(dele);
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

