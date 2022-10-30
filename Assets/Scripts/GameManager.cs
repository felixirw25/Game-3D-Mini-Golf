using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject pausePanel;
    [SerializeField] TMP_Text attemptText;
    [SerializeField] TMP_Text gameOvertext;
    [SerializeField] PlayerController playerController;
    [SerializeField] Hole hole;
    // Start is called before the first frame update
    public void SetPause(bool isPause){
        if(isPause){
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            gameCanvas.SetActive(false);
        }
        else{
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            gameCanvas.SetActive(true);
        }
    }
    private void Awake(){
        Debug.Log("Max Level di Awake: " + PlayerPrefs.GetInt("maxlevel"));
    }    
    private void Start()
    {
        Time.timeScale = 1;
        Debug.Log("Max Level di Start: " + PlayerPrefs.GetInt("maxlevel"));
        if(PlayerPrefs.GetInt("maxlevel")<=0){
            PlayerPrefs.SetInt("maxlevel", 1);
        }
        else{
            PlayerPrefs.GetInt("maxlevel", 1);
        }
        
        if(gameOverPanel==null || gameOvertext==null || playerController==null || hole==null || pausePanel==null)
            return;
        
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameOverPanel==null || gameOvertext==null || playerController==null || hole==null)
            return;
            
        if(hole.Entered && gameOverPanel.activeInHierarchy == false){
            attemptText.enabled = false;
            gameOverPanel.SetActive(true);
            gameOvertext.text = "Total Attempt: " + playerController.ShootCountText;
            playerController.enabled = false;
        }
    }
    public void BackToMainMenu(){
        SceneLoader.Load("MainMenu");
    }
    public void LevelSelect(){
        SceneLoader.Load("Level0");
    }
    public void Replay(){
        SceneLoader.ReloadLevel();
    }
    public void PlayNext(){
        SceneLoader.LoadNextLevel();
    }
    public void PlayLevel(string sceneName){
        Debug.Log("lagi aktif: " + sceneName);
        SceneLoader.Load(sceneName);
    }
}
