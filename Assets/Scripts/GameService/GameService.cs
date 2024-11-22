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

    #region VIEWS
    [SerializeField] LobbyView lobbyView;
    [SerializeField] LevelManager levelManager;
    #endregion

    #region DATA
    [SerializeField] List<InGameLevelControllerSO> InGameControllers;
    [SerializeField] List<LevelObject> levelDataList;

    [SerializeField] AudioSource bGAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] SoundTypes[] soundTypes;
    private InGameLevelControllerSO currentInGameController;
    #endregion

    #region SERVICES
    private UIService uIService;
    private SoundManager soundManager;
    public UIService UIService { get { return uIService; } }
    public SoundManager SoundManager { get { return soundManager; } }
    #endregion

    private void Init()
    {
        
        uIService=new UIService(lobbyView,levelManager);
        soundManager = new SoundManager(bGAudioSource, sfxAudioSource, soundTypes);
        SoundManager.SetupBgSound(SoundNames.BACKGROUND);
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
}
