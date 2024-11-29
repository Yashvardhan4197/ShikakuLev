
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LobbyView : MonoBehaviour
{
    [SerializeField] LobbyController lobbyController;
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] Button HowToPlayButton;
    [SerializeField] Button GoBackButton;

    [SerializeField] Button GoBackHowToPlayButton;
    [SerializeField] Button GoNextHowToPlayButton;
    [SerializeField] Button GoPrevHowToPlayButton;
    [SerializeField] TextMeshProUGUI HowToPlayPageNumber;
    [SerializeField] GameObject LobbyPopUp;
    [SerializeField] GameObject HowToPlayPopUp;

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject[] tutorialPopUps;

    private void Start()
    {
        lobbyController = GameService.Instance.UIService.GetLobbyController();
        lobbyController.SetOnStartDependency(tutorialPopUps,this);
        StartButton.onClick.AddListener(OpenLevelSelection);
        EndButton.onClick.AddListener(ExitGame);
        GoBackButton.onClick.AddListener(OnGoBackButtonClick);
        HowToPlayButton.onClick.AddListener(OnHowToPlayButtonClick);
        GoBackHowToPlayButton.onClick.AddListener(OnGoBackHowToPlayButtonClicked);
        GoNextHowToPlayButton.onClick.AddListener(OnGoNextHowToPlayButtonClicked);
        GoPrevHowToPlayButton.onClick.AddListener(OnGoPrevHowToPlayButtonClicked);
        LobbyPopUp.SetActive(false);
        HowToPlayPopUp.SetActive(false);
    }

    private void OnGoPrevHowToPlayButtonClicked()
    {
        lobbyController.OpenPrevPageInHowToPlay();
    }

    private void OnGoNextHowToPlayButtonClicked()
    {
        
        lobbyController.OpenNextPageInHowToPlay();
    }

    private void OnHowToPlayButtonClick()
    {
        HowToPlayPopUp?.SetActive(true);
        lobbyController.OnHowToPlayButtonClicked();
        GameService.Instance.SoundManager.PlaySound(SoundNames.BUTTON_CLICK);
    }

    private void OnGoBackHowToPlayButtonClicked()
    {
        HowToPlayPopUp?.SetActive(false);
        GameService.Instance.SoundManager.PlaySound(SoundNames.DESELECT);
    }

    private void OnGoBackButtonClick()
    {
        LobbyPopUp?.SetActive(false);
        GameService.Instance.SoundManager.PlaySound(SoundNames.DESELECT);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void OpenLevelSelection()
    {
        LobbyPopUp.SetActive(true);
        GameService.Instance.SoundManager.PlaySound(SoundNames.BUTTON_CLICK);
    }

    public void SetController(LobbyController LobbyController)
    {
        lobbyController = LobbyController;
    }

    public TextMeshProUGUI GetHowToPlayPageNumber()
    {
        return HowToPlayPageNumber;
    }

    public VideoPlayer GetVideoPlayer()=>videoPlayer;

}
