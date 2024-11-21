﻿
using UnityEngine;

public class LobbyController
{
    private LobbyView lobbyView;
    private LevelManager levelManager;
    //private static int currentLevel;
    public LobbyController(LobbyView lobbyView, LevelManager levelManager)
    {
        this.lobbyView = lobbyView;
        lobbyView.SetController(this);
        this.levelManager = levelManager;
    }

    public Color GetLevelButtonColor(LevelStatus levelStatus)
    {
        return levelManager.GetColor(levelStatus);
    }

    public void SetLevelStatus(int currentlevel,LevelStatus levelStatus)
    {
        levelManager.SetLevelStatus(currentlevel,levelStatus);
    }

    public void OnSceneLoad()
    {
        //levelManager.OnSceneLoad();
    }
}

