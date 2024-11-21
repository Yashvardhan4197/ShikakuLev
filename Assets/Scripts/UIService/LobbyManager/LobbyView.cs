
using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] GameObject LobbyPopUp;

    private void Start()
    {
        StartButton.onClick.AddListener(OpenLevelSelection);
        LobbyPopUp.SetActive(false);
    }

    private void OpenLevelSelection()
    {
        LobbyPopUp.SetActive(true);
    }

    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

}
