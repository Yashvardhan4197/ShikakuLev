using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] LevelData[] levelColorData;
    [SerializeField] List<LevelObject> levelDataList;
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
        foreach(LevelObject lvlObject in levelDataList)
        {
            if(lvlObject.LevelNumber==currentLevelNumber)
            {
                lvlObject.levelStatus = levelStatus;
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