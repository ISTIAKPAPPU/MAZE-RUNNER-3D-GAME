using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenefast : MonoBehaviour
{
    void Update()
    {
       
            StartCoroutine(LoadYourAsyncScene());
        
    }

    IEnumerator LoadYourAsyncScene()
    {
     

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("00_start_screen/01_main_menu,SelectStage/HowTo/Stage1/Stage2/GameStory/UnlockNav/EndStory");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
