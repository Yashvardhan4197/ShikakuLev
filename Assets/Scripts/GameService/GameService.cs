using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameService : MonoBehaviour
{
    #region SINGLETON SETUP
    private static GameService instance;
    public static GameService Instance {  get { return instance; } }
    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        Init();
    }
    #endregion

    //VIEWS
    [SerializeField] LobbyView lobbyView;
    [SerializeField] LevelManager levelManager;

    //DATA
    [SerializeField] List<InGameLevelControllerSO> InGameControllers;
    [SerializeField] List<LevelObject> levelDataList;
    private InGameLevelControllerSO currentInGameController;
    //SERVICES
    private UIService uIService;
    public UIService UIService { get { return uIService; } }

    //ACTIONS
    public UnityAction StartLevel;
    private void Init()
    {
        uIService=new UIService(lobbyView,levelManager);
        //levelManager.SetLevelBoxesList(levelDataList);
        StartLevel += OnSceneLoad;
    }

    public void OnSceneLoad()
    {
    }

    public void SetInGameController(int levelNumber)
    {
        foreach(var controller in  InGameControllers)
        {
            if(controller.levelNumber == levelNumber)
            {
                currentInGameController = controller;
                return;
            }
        }
    }

    public InGameLevelControllerSO GetInGameLevelController()=>currentInGameController;
    public int GetTotalSceneCount()=>InGameControllers.Count;
}
