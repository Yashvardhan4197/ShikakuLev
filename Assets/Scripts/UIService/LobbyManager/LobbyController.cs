using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LobbyController
{
    private LobbyView lobbyView;
    private LevelManager levelManager;
    private TutorialPopUpForController[] tutorialPopUpData;
    private TutorialPopUpSO[] tutorialPopUpSOs;
    private int currentPageNumber;
    public LobbyController(LobbyView lobbyView,LevelManager levelManager, TutorialPopUpSO[] tutorialPopUpDataSOs)
    {
        this.lobbyView = lobbyView;
        this.levelManager = levelManager;
        lobbyView.SetController(this);
        this.tutorialPopUpSOs = tutorialPopUpDataSOs;
        tutorialPopUpData=new TutorialPopUpForController[tutorialPopUpDataSOs.Length];
        for(int i=0;i<tutorialPopUpDataSOs.Length;i++)
        {
            tutorialPopUpData[i] = new TutorialPopUpForController();
        }
    }

    public Color GetLevelButtonColor(LevelStatus levelStatus)
    {
        return levelManager.GetColor(levelStatus);
    }

    public void SetLevelStatus(int currentlevel,LevelStatus levelStatus)
    {
        levelManager.SetLevelStatus(currentlevel,levelStatus);
    }

    public void OnHowToPlayButtonClicked()
    {
        currentPageNumber = 1;
        OpenPageNumber();
    }

    private void SetHowToPlayPageNumber(int currentPageNumber)
    {
        TextMeshProUGUI temp = lobbyView.GetHowToPlayPageNumber();
        temp.text = currentPageNumber.ToString()+"/"+tutorialPopUpData.Length.ToString();
    }

    private void OpenPageNumber()
    {
        for (int i = 0; i < tutorialPopUpData.Length; i++)
        {
            if (i + 1 == currentPageNumber)
            {
                tutorialPopUpData[i].tutorialPopUpGameObject.SetActive(true);
                lobbyView.GetVideoPlayer().url = tutorialPopUpData[i].videoClipURL;
                SetHowToPlayPageNumber(currentPageNumber);
                lobbyView.GetVideoPlayer().targetTexture = tutorialPopUpData[i].renderTexture;
            }
            else
            {
                tutorialPopUpData[i].tutorialPopUpGameObject.SetActive(false);
            }
        }
    }


    public void OpenNextPageInHowToPlay()
    {
        currentPageNumber++;
        if (currentPageNumber > tutorialPopUpData.Length) { currentPageNumber = 1; }
        OpenPageNumber();
    }

    internal void OpenPrevPageInHowToPlay()
    {
        currentPageNumber--;
        if(currentPageNumber <= 0) { currentPageNumber = tutorialPopUpData.Length; }
        OpenPageNumber();
    }

    public void SetOnStartDependency(GameObject[] tutorialPopUps,LobbyView lobbyView)
    {
        this.lobbyView = lobbyView;
        for(int i = 0;i<tutorialPopUpData.Length;i++)
        {
            tutorialPopUpData[i].tutorialPopUpGameObject = tutorialPopUps[i];
            tutorialPopUpData[i].videoClipURL = tutorialPopUpSOs[i].VideoClipURL;
            tutorialPopUpData[i].renderTexture = tutorialPopUpSOs[i].RenderTexture;
        }
    }

}

