using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BoxHandler : MonoBehaviour
{
    [SerializeField] int boxNumber;
    public Color boxColor;
    public Color defaultColor;
    public bool isCompleted = false;
    public GameObject parentBox = null;
    [SerializeField] TextMeshProUGUI numberText;
    private bool flag = false;
    private void Awake()
    {
        CheckUsability();
    }

    private void CheckUsability()
    {
        if(boxNumber<=0)
        {
            numberText.gameObject.SetActive(false);
        }
        else
        {
            numberText.gameObject.SetActive(true);
            numberText.text=boxNumber.ToString();
        }
    }

    public void PointerDown()
    {
        
        if(boxNumber>0)
        {
            GameService.Instance.GetInGameLevelController().SetTimerStatus(true);
            gameObject.GetComponent<Image>().color = boxColor;
        }
        BoardHandler.Instance.OnBoxClicked(this);
        GameService.Instance.SoundManager.PlaySound(SoundNames.BUTTON_CLICK);
        
    }

    public int GetBoxNumber()=> boxNumber;
}
