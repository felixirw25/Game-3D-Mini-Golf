using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip goalClip;
    bool entered = false;

    public bool Entered { get => entered; }

    private void OnTriggerEnter(){
        entered = true;
        audioSource.PlayOneShot(goalClip);
        int.TryParse(SceneManager.GetActiveScene().name.Split("Level")[1], out int currentLevel);
        PlayerPrefs.SetInt("maxlevel", currentLevel+1);
    }
}
