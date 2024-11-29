
public class UIService
{
    private LobbyController lobbyController;
    public UIService(LobbyView lobbyView,LevelManager levelManager, TutorialPopUpSO[] tutorialPopUps)
    {
        lobbyController=new LobbyController(lobbyView,levelManager,tutorialPopUps);
    }

    public LobbyController GetLobbyController() => lobbyController;
}
