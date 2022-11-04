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
    }
}
// GenericPropertyJSON:{"name":"listLevels","type":-1,"arraySize":4,"arrayType":"LevelData","children":[{"name":"Array","type":-1,"arraySize":4,"arrayType":"LevelData","children":[{"name":"size","type":12,"val":4},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Easy"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"5f7d04845e3ad594c8884eb8737abae3\",\"localId\":21300000,\"type\":3,\"instanceID\":24846}"},{"name":"levelScene","type":3,"val":"Level1"},{"name":"isUnlock","type":1,"val":true},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Medium"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"e088f52d5d2ca61458466a974dc89d77\",\"localId\":21300000,\"type\":3,\"instanceID\":24848}"},{"name":"levelScene","type":3,"val":"Level2"},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Hard"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"a7bc2e15fba1f5e4294e3e350ea564e1\",\"localId\":21300000,\"type\":3,\"instanceID\":24850}"},{"name":"levelScene","type":3,"val":"Level3"},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":false}]},{"name":"data","type":-1,"children":[{"name":"levelName","type":3,"val":"Coming Soon"},{"name":"levelSprite","type":5,"val":"UnityEditor.ObjectWrapperJSON:{\"guid\":\"2ca626ff1ec5a4e4ea2194e2635e2e4e\",\"localId\":21300000,\"type\":3,\"instanceID\":24330}"},{"name":"levelScene","type":3,"val":"Level4"},{"name":"isUnlock","type":1,"val":false},{"name":"isComing","type":1,"val":true}]}]}]}