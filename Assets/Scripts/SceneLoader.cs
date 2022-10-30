using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string sceneToLoad;

    public static string SceneToLoad { get => sceneToLoad; }

    // Load
    public static void Load(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    // Progress Load
    public static void ProgressLoad(string sceneName){
        sceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingProgress");
    }

    // ReloadLevel
    public static void ReloadLevel(){
        var currentScene = SceneManager.GetActiveScene().name;
        ProgressLoad(currentScene);
    }

    //LoadNextLevel
    public static void LoadNextLevel(){
        string currentScene = SceneManager.GetActiveScene().name;  
        Debug.Log("Current Scene: " + currentScene);   
        int nextLevel = int.Parse(currentScene.Split("Level")[1])+1;
        Debug.Log("nextLevel Scene: " + nextLevel);   
        string nextSceneName = "Level" + nextLevel;
        Debug.Log("nextLevel Scene: " + nextSceneName);   


        if(SceneUtility.GetBuildIndexByScenePath(nextSceneName)==-1){
            Debug.LogError(nextSceneName+ "not released yet!");
            return;
        }
        ProgressLoad(nextSceneName);
    }
}
