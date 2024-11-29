
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelObject : MonoBehaviour
{
    public LevelStatus levelStatus;
    public int LevelNumber;
    private void Start()
    {
        Invoke("SetColor", 0.2f);
    }


    private void SetColor()
    {
        if (levelStatus == LevelStatus.LOCKED)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        gameObject.GetComponent<Button>().image.color = GameService.Instance.UIService.GetLobbyController().GetLevelButtonColor(levelStatus);

        gameObject.GetComponent<Button>().onClick.AddListener(OpenLevel);
    }

    private void OpenLevel()
    {
        SceneManager.LoadScene(LevelNumber);
        GameService.Instance.SetInGameController(LevelNumber);
        GameService.Instance.SoundManager.PlaySound(SoundNames.BUTTON_CLICK);
    }
}
