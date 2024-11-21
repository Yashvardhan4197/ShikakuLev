
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject WinScreenPopUp;
    [SerializeField] GameObject PauseMenuPopUp;
    [SerializeField] InGameLevelControllerSO InGameController;

    [SerializeField] Button PauseButton;
    [SerializeField] Button NextButton;
    [SerializeField] Button ExitButton;
    [SerializeField] Button PauseExitButton;

    private bool paused = false;
    private void Start()
    {
        WinScreenPopUp.SetActive(false);
        PauseMenuPopUp.SetActive(false);
        paused = false;
        PauseButton.onClick.AddListener(OnGamePause);
        InGameController.SetView(this);
        ExitButton.onClick.AddListener(ExitToLobby);
        PauseExitButton.onClick.AddListener(ExitToLobby);
        NextButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void ExitToLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void InGameWon()
    {
        WinScreenPopUp?.SetActive(true);
    }

    public void OnGamePause()
    {
        if (paused == false)
        {
            PauseMenuPopUp?.SetActive(true);
            paused = true;
        }
        else
        {
            paused = false;
            PauseMenuPopUp.SetActive(false);
        }
    }

    public void OnNextButtonClicked()
    {
        InGameController?.GoToNextlevel();
    }
}
