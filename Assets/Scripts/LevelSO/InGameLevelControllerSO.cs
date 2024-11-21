
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="LevelController",menuName ="ScriptableObjects/NewLevelController")]
public class InGameLevelControllerSO : ScriptableObject
{
    public int levelNumber;
    [SerializeField] private int WinningCondition;
    private InGameView inGameView;
    private int currentScore;
    public void SetView(InGameView inGameView)
    {
        this.inGameView = inGameView;
        Init();
    }

    private void Init()
    {
        inGameView.SetScoreText(currentScore);
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;
        inGameView.SetScoreText(currentScore);
        if(currentScore >= WinningCondition) 
        {
            inGameView.InGameWon();
            GameService.Instance.UIService.GetLobbyController().SetLevelStatus(levelNumber,LevelStatus.COMPLETED);
        }
    }

    public void GoToNextlevel()
    {
        GameService.Instance.SetInGameController(levelNumber + 1);
        Debug.Log("Wassupppppp nigga" + SceneManager.sceneCountInBuildSettings);
        if (SceneManager.sceneCountInBuildSettings <= levelNumber+1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(levelNumber + 1);
        }
    }

}
