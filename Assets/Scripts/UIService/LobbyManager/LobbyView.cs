
using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    private LobbyController lobbyController;
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] GameObject LobbyPopUp;
    public void SetController(LobbyController lobbyController)
    {
        this.lobbyController = lobbyController;
    }

    private void Start()
    {
        StartButton.onClick.AddListener(OpenLevelSelection);
    }

    private void OpenLevelSelection()
    {
        LobbyPopUp.SetActive(true);
    }
}
