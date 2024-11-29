using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] LevelData[] levelColorData;
    [SerializeField] List<LevelObject> levelDataList;

    private void Awake()
    {
        if (FBPP.GetInt("Level" + 1, -1) == -1)
        {
            FBPP.SetInt("Level" + 1, 0);
            FBPP.Save();
        }
    }

    private void Start()
    {
        Invoke("SetStatusOnLoad", 0.1f);
        lobbyController = GameService.Instance.UIService.GetLobbyController();
    }


    private void SetStatusOnLoad()
    {
        for (int i = 0; i < levelDataList.Count; i++)
        {
            levelDataList[i].levelStatus = (LevelStatus)FBPP.GetInt("Level" + levelDataList[i].LevelNumber, 1);
            Debug.Log("level:" + levelDataList[i].LevelNumber + "=" + levelDataList[i].levelStatus);
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
        for (int i = 0; i < levelDataList.Count; i++)
        {
            if (levelDataList[i].LevelNumber == currentLevelNumber)
            {
                levelDataList[i].levelStatus = levelStatus;
                FBPP.SetInt("Level" + levelDataList[i].LevelNumber, (int)levelStatus);
                if (levelStatus == LevelStatus.COMPLETED)
                {
                    if (i < levelDataList.Count - 1)
                    {
                        if (levelDataList[i + 1].levelStatus == LevelStatus.LOCKED)
                        {

                            levelDataList[i + 1].levelStatus = LevelStatus.UNLOCKED;
                            FBPP.SetInt("Level" + levelDataList[i + 1].LevelNumber, 0);
                        }
                    }
                }
                FBPP.Save();
                return;
            }
        }
    }

}
