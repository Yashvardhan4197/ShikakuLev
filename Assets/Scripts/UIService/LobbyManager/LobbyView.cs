
using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] Button HowToPlayButton;
    [SerializeField] Button GoBackHowToPlayButton;
    [SerializeField] Button GoBackButton;
    [SerializeField] GameObject LobbyPopUp;
    [SerializeField] GameObject HowToPlayPopUp;

    private void Start()
    {
        StartButton.onClick.AddListener(OpenLevelSelection);
        EndButton.onClick.AddListener(ExitGame);
        GoBackButton.onClick.AddListener(OnGoBackButtonClick);
        HowToPlayButton.onClick.AddListener(OnHowToPlayButtonClick);
        GoBackHowToPlayButton.onClick.AddListener(OnGoBackHowToPlayButtonClicked);
        LobbyPopUp.SetActive(false);
        HowToPlayPopUp.SetActive(false);
    }

    private void OnHowToPlayButtonClick()
    {
        HowToPlayPopUp?.SetActive(true);
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

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

}
