
public class UIService
{
    private LobbyController lobbyController;
    public UIService(LobbyView lobbyView,LevelManager levelManager)
    {
        lobbyController=new LobbyController(lobbyView, levelManager);
    }

    public LobbyController GetLobbyController() => lobbyController;
}
