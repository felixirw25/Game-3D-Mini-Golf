using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text loadingText;
    
    private void Start(){
        StartCoroutine(Progress());
    }
    IEnumerator Progress(){
        image.fillAmount = 0;
        yield return new WaitForSeconds(1);

        var asyncOp = SceneManager.LoadSceneAsync(SceneLoader.SceneToLoad);

        while(asyncOp.isDone==false){
            image.fillAmount = asyncOp.progress;
            Debug.Log(asyncOp.progress*100);
            loadingText.text = (asyncOp.progress*100).ToString() + " /100%";
            yield return null;
        }
    }
}
