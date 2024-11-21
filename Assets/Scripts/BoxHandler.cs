using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BoxHandler : MonoBehaviour
{
    [SerializeField] int boxNumber;
    [SerializeField] Color boxColor;
    public Color defaultColor;
    public bool isCompleted = false;
    public GameObject parentBox = null;
    [SerializeField] TextMeshProUGUI numberText;
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
            gameObject.GetComponent<Image>().color= boxColor;
        }
        //Call ValidityHandler
        BoardHandler.Instance.OnBoxClicked(this);
    }

    public int GetBoxNumber()=> boxNumber;
}
