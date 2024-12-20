
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="LevelController",menuName ="ScriptableObjects/NewLevelController")]
public class InGameLevelControllerSO : ScriptableObject
{
    [SerializeField] int WinningCondition;
    private InGameView inGameView;
    private int currentScore;
    private float timer = 0;
    public int levelNumber;
    private bool timerStatus;

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
        if (SceneManager.sceneCountInBuildSettings <= levelNumber+1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(levelNumber + 1);
        }
    }

    public void SetView(InGameView inGameView)
    {
        this.inGameView = inGameView;
        Init();
    }

    public void StartTimer()
    {
        if(timerStatus==true)
        {
            timer += Time.deltaTime;
            inGameView.SetTimer(timer);
        }
        
    }

    public void SetTimerStatus(bool status)
    {
        timerStatus = status;
    }

    public void SetTimerStatus(bool status,int time)
    {
        timerStatus=status;
        timer = time;
    }

}
