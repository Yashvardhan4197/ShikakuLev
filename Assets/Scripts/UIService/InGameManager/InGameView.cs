
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI HighScoreTime;
    [SerializeField] GameObject WinScreenPopUp;
    [SerializeField] GameObject PauseMenuPopUp;
    [SerializeField] InGameLevelControllerSO InGameController;

    [SerializeField] Button PauseButton;
    [SerializeField] Button ResumeButton;
    [SerializeField] Button NextButton;
    [SerializeField] Button ExitButton;
    [SerializeField] Button PauseExitButton;

    private bool paused = false;
    private float currentTime;
    private float highTime;
    private void Start()
    {
        WinScreenPopUp.SetActive(false);
        PauseMenuPopUp.SetActive(false);
        paused = false;
        PauseButton.enabled = true;
        PauseButton.onClick.AddListener(OnGamePause);
        InGameController.SetView(this);
        ExitButton.onClick.AddListener(ExitToLobby);
        PauseExitButton.onClick.AddListener(ExitToLobby);
        NextButton.onClick.AddListener(OnNextButtonClicked);
        ResumeButton.onClick.AddListener(OnResumeButtonClicked);
        highTime = FBPP.GetFloat("Timer" + InGameController.levelNumber, float.MaxValue);
        currentTime = 0;
        InGameController.SetTimerStatus(false,0);
    }

    private void OnResumeButtonClicked()
    {
        paused = false;
        PauseMenuPopUp?.SetActive(false);
    }

    private void ExitToLobby()
    {
        SceneManager.LoadScene(0);
        GameService.Instance.SoundManager.PlaySound(SoundNames.DESELECT);
    }

    private void Update()
    {
        InGameController.StartTimer(); 
    }

    public void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void InGameWon()
    {
        WinScreenPopUp?.SetActive(true);
        GameService.Instance.SoundManager.PlaySound(SoundNames.GAME_OVER);
        PauseButton.enabled = false;
        SetHighScore();
    }

    public void OnGamePause()
    {
        if (paused == false)
        {
            PauseMenuPopUp?.SetActive(true);
            GameService.Instance.SoundManager.PlaySound(SoundNames.BUTTON_CLICK);
            //InGameController.SetTimerStatus(false);
            paused = true;
        }
        else
        {
            paused = false;
            PauseMenuPopUp.SetActive(false);
            GameService.Instance.SoundManager.PlaySound(SoundNames.DESELECT);
            //InGameController.SetTimerStatus(true);
        }
    }

    public void OnNextButtonClicked()
    {
        InGameController?.GoToNextlevel();
    }

    public void SetTimer(float timeSpan)
    {
        currentTime = timeSpan;
        TimeSpan temp=TimeSpan.FromSeconds(timeSpan);
        TimerText.text = String.Format("{0:00}:{1:00}", temp.Minutes, temp.Seconds);
    }

    public void SetHighScore()
    {
        InGameController.SetTimerStatus(false);
        if (highTime>currentTime)
        {
            highTime = currentTime;
            FBPP.SetFloat("Timer"+InGameController.levelNumber,highTime);
        }
        TimeSpan temp=TimeSpan.FromSeconds(highTime);
        //HighScoreTime.text=temp.Minutes.ToString()+":"+temp.Seconds.ToString();
        HighScoreTime.text = String.Format("{0:00}:{1:00}",temp.Minutes,temp.Seconds);
        FBPP.Save();
    }
}
