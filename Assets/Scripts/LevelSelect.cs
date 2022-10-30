using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] Image levelImage;
    [SerializeField] TMP_Text levelName;
    public AutomaticLevel.LevelData levelData;
    // Start is called before the first frame update
    public void SetLevel(AutomaticLevel.LevelData data)
    {
        levelImage.sprite = data.levelSprite;
        levelName.text = data.levelName;
        levelData = data;
    }
    public void LevelOnClick()
    {
        int.TryParse(levelData.levelScene.Split("Level")[1], out int currentLevel);
        if(currentLevel<=PlayerPrefs.GetInt("maxlevel")){
            GameManager gameManager = new GameManager();
            gameManager.PlayLevel(levelData.levelScene);
        }
        else{
            
        }
    }
}
// GenericPropertyJSON:{"name":"listLevels","type":-1,"arraySize":4,"arrayType":"LevelData","children":[{"name":"Array","type":-1,"arraySize":4,"arrayType":"LevelData","children":[{"name":"size","type":12,"val":4},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Easy"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"5f7d04845e3ad594c8884eb8737abae3\",\"localId\":21300000,\"type\":3,\"instanceID\":24554}"},{"name":"levelScene","type":3,"val":"Level1"},{"name":"isUnlock","type":1,"val":true},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Medium"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"e088f52d5d2ca61458466a974dc89d77\",\"localId\":21300000,\"type\":3,\"instanceID\":57834}"},{"name":"levelScene","type":3,"val":"Level2"},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Hard"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"e088f52d5d2ca61458466a974dc89d77\",\"localId\":21300000,\"type\":3,\"instanceID\":57834}"},{"name":"levelScene","type":3,"val":""},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Super Hard"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"e088f52d5d2ca61458466a974dc89d77\",\"localId\":21300000,\"type\":3,\"instanceID\":57834}"},{"name":"levelScene","type":3,"val":""},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":true}]}]}]}