
using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] Button GoBackButton;
    [SerializeField] GameObject LobbyPopUp;

    private void Start()
    {
        StartButton.onClick.AddListener(OpenLevelSelection);
        EndButton.onClick.AddListener(ExitGame);
        GoBackButton.onClick.AddListener(OnGoBackButtonClick);
        LobbyPopUp.SetActive(false);
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
