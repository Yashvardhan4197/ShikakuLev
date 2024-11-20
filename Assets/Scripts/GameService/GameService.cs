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


    //SERVICES
    private UIService uIService;
    private BoardHandler boardHandler;
    public UIService UIService { get { return uIService; } }
    public BoardHandler BoardHandler { get {  return boardHandler; } }

    //ACTIONS
    public UnityAction StartLevel;
    private void Init()
    {
        uIService=new UIService(lobbyView,levelManager);
        boardHandler = new BoardHandler();
        StartLevel += OnSceneLoad;
    }

    public void OnSceneLoad()
    {
        boardHandler.Reset();
    }
}
