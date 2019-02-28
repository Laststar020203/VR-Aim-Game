using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public static void NextSceneLoad()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public static void IndexLoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void UILoadScene()
    {
        NextSceneLoad();
    }
    

}
