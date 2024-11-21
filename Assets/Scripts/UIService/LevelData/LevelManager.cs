using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] LevelData[] levelColorData;
    [SerializeField] List<LevelObject> levelDataList;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Level"+1,-1)==-1)
        {
            PlayerPrefs.SetInt("Level" + 1, 0);
        }
    }

    private void Start()
    {
        for (int i = 0; i < levelDataList.Count; i++)
        {
            levelDataList[i].levelStatus = (LevelStatus)PlayerPrefs.GetInt("Level" + levelDataList[i].LevelNumber, 1);
            Debug.Log("LevelStatus for " + levelDataList[i].LevelNumber + ": " + (LevelStatus)PlayerPrefs.GetInt("Level" + levelDataList[i].LevelNumber, 1));
        }
    }

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    public Color GetColor(LevelStatus levelStatus)
    {
        for (int i = 0; i < levelColorData.Length; i++)
        {
            if (levelColorData[i].LevelStatus == levelStatus)
            {
                return levelColorData[i].Color;
            }
        }
        return Color.grey;
    }

    public void SetLevelStatus(int currentLevelNumber, LevelStatus levelStatus)
    {
        for(int i = 0;i < levelDataList.Count;i++)
        {
            if (levelDataList[i].LevelNumber ==currentLevelNumber)
            {
                levelDataList[i].levelStatus = levelStatus;
                PlayerPrefs.SetInt("Level" + levelDataList[i].LevelNumber,(int)levelStatus);
                if (levelStatus==LevelStatus.COMPLETED)
                {
                    if(i<levelDataList.Count-1)
                    {
                        if (levelDataList[i + 1].levelStatus == LevelStatus.LOCKED)
                        {
                            
                            levelDataList[i + 1].levelStatus = LevelStatus.UNLOCKED;
                            PlayerPrefs.SetInt("Level" + levelDataList[i+1].LevelNumber, 0);
                        }
                    }
                }
                return;
            }
        }
    }

}

[System.Serializable]
public class LevelData
{
    public LevelStatus LevelStatus;
    public Color Color;
}