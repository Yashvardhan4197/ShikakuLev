
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameService : MonoBehaviour
{
    #region SINGLETON SETUP
    private static GameService instance;
    public static GameService Instance { get { return instance; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    #endregion

    #region VIEWS
    [SerializeField] LobbyView lobbyView;
    [SerializeField] LevelManager levelManager;
    #endregion

    #region DATA
    [SerializeField] List<InGameLevelControllerSO> InGameControllers;
    [SerializeField] AudioSource bGAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] SoundTypes[] soundTypes;
    [SerializeField] TutorialPopUpSO[] tutorialPopUps;
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

        uIService = new UIService(lobbyView, levelManager, tutorialPopUps);
        soundManager = new SoundManager(bGAudioSource, sfxAudioSource, soundTypes);
        SoundManager.SetupBgSound(SoundNames.BACKGROUND);

        var config = new FBPPConfig()
        {
            SaveFileName = "my-save-file.txt",
            AutoSaveData = false,
            ScrambleSaveData = true,
            EncryptionSecret = "my-secret",
            SaveFilePath = Application.persistentDataPath
        };
        // pass it to FBPP
        FBPP.Start(config);
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
