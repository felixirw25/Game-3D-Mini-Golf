using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticLevel : MonoBehaviour
{
    [SerializeField] public LevelData[] listLevels;
    [SerializeField] GameObject levelPrefab;
    [SerializeField] Transform parent;
    
    [System.Serializable]
    public class LevelData{
        [SerializeField] public string levelName;
        [SerializeField] public Sprite levelSprite;
        [SerializeField] public string levelScene;
        [SerializeField] public bool isUnlock;
        [SerializeField] public bool isComing;
    }
    // progress level

    // Start is called before the first frame update
    private void Start()
    {
        int indexLevel = 0;
        foreach(LevelData levelData in listLevels){
            indexLevel++;
            GameObject go = Instantiate(levelPrefab, parent);
            // spriteRenderer = go.GetComponent<SpriteRenderer>();
            LevelSelect levelSelect = go.GetComponent<LevelSelect>();

            if(levelSelect != null) 
                levelSelect.SetLevel(levelData);
            
            if(indexLevel>PlayerPrefs.GetInt("maxlevel")){
                go.GetComponent<Image>().color=new Color32(0,0,0,100);
            }
        }
    }
}