
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardHandler: MonoBehaviour 
{
    /*
    private static BoardHandler instance;
    public static BoardHandler Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    */

    private List<GameObject> selectedBoxes = new List<GameObject>();
    private Dictionary<BoxHandler,List<GameObject>>NumberPairs = new Dictionary<BoxHandler,List<GameObject>>();
    private GameObject numberbox;
    private int score;


    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        selectedBoxes.Clear();
        numberbox = null;
        NumberPairs.Clear();
        score = 0;
    }

    private void UpdateSSS()
    {
        score = 0;
        foreach(var current in NumberPairs.Keys)
        {
            if (current.GetBoxNumber() == NumberPairs[current].Count&&CheckValidRegion(numberbox))
            {
                score++;
            }
        }
        Debug.Log("Score is: " + score);
    }

    private void UpdatePair()
    {
        if(numberbox != null)
        {
            NumberPairs[numberbox.GetComponent<BoxHandler>()] = selectedBoxes;
            Debug.Log("Updated Pair Value" + NumberPairs[numberbox.GetComponent<BoxHandler>()].Count);
        }
    }

    private void ClearPair(BoxHandler currentBox)
    {
        if (currentBox.isCompleted == true) 
        { 
            //UpdateScore(-1);
            currentBox.isCompleted = false; 
        }

        List<GameObject> temp = NumberPairs[currentBox];
        foreach (GameObject obj in temp)
        {
            obj.GetComponent<Image>().color = obj.GetComponent<BoxHandler>().defaultColor;
            obj.GetComponent<BoxHandler>().parentBox = null;
        }
        NumberPairs.Remove(currentBox);
        selectedBoxes.Clear();
    }

    public void OnBoxClicked(BoxHandler newBox)
    {
        var boxHandler = newBox.GetComponent<BoxHandler>();
        if (numberbox==null && boxHandler.GetBoxNumber()>0)
        {
            HandleFirstSelection(newBox);
            UpdatePair();

        }
        else if(numberbox!=null)
        {
            if (newBox.GetComponent<BoxHandler>().GetBoxNumber() > 0)
            {
                ClearPair(numberbox.GetComponent<BoxHandler>());
                if (NumberPairs.ContainsKey(newBox))
                {
                    ClearPair(newBox);
                    numberbox = null;
                }
                else
                {
                    NumberPairs.Add(newBox, new List<GameObject>());
                    selectedBoxes = NumberPairs[newBox];
                    selectedBoxes.Add(newBox.gameObject);
                    numberbox = newBox.gameObject;
                    newBox.GetComponent<BoxHandler>().parentBox = numberbox;
                    UpdatePair();
                }
                
            }
            else if (selectedBoxes.Count < numberbox.GetComponent<BoxHandler>().GetBoxNumber())
            {
                ToggleBoxSelection(newBox);
            }
            else if (numberbox == boxHandler?.parentBox)
            {
                DeselectBox(newBox);
                UpdatePair();
            }
            else if (newBox.gameObject == numberbox)
            {
                ClearPair(newBox);
                UpdatePair();
                numberbox = null;
            }
        }
        
        Debug.Log(selectedBoxes.Count);


        UpdateSSS();

        if (CheckValidRegion(numberbox))
        {
            numberbox.GetComponent<BoxHandler>().isCompleted = true;
            numberbox = null;
        }
   
    }

    private void ToggleBoxSelection(BoxHandler newBox)
    {
        if (!selectedBoxes.Contains(newBox.gameObject))
        {
            if(newBox.parentBox!=null)
            {
                NumberPairs[newBox.parentBox.GetComponent<BoxHandler>()].Remove(newBox.gameObject);
            }
            selectedBoxes.Add(newBox.gameObject);
            newBox.parentBox = numberbox;//set parent box
            newBox.gameObject.GetComponent<Image>().color = numberbox.GetComponent<Image>().color;//set new Box color
        }
        else
        {
            DeselectBox(newBox);
        }
        UpdatePair();
    }

    private void DeselectBox(BoxHandler newBox)
    {
        selectedBoxes.Remove(newBox.gameObject);
        newBox.parentBox = null;//set parent box
        newBox.gameObject.GetComponent<Image>().color = newBox.GetComponent<BoxHandler>().defaultColor;//set new Box color
    }


    private void HandleFirstSelection(BoxHandler newBox)
    {
        if (NumberPairs.ContainsKey(newBox))
        {
            
            ClearPair(newBox);
        }
        else
        {
            NumberPairs.Add(newBox, new List<GameObject>());
            selectedBoxes = NumberPairs[newBox];
            selectedBoxes.Add(newBox.gameObject);
            numberbox = newBox.gameObject;
            newBox.GetComponent<BoxHandler>().parentBox = numberbox;
        } 
    }

    private bool CheckValidRegion(GameObject mainBox)
    {

        if(selectedBoxes.Count != mainBox?.GetComponent<BoxHandler>().GetBoxNumber()) { return false; }

        if(IsRectangle(mainBox))
        {
            return true;
        }
        return false;
    }

    private bool IsRectangle(GameObject mainBox)
    {
        int minX= int.MaxValue;
        int minY= int.MaxValue;
        int maxX= int.MinValue;
        int maxY= int.MinValue;
        float cellSize = 100f;
        HashSet<Vector2>boxPositions = new HashSet<Vector2>();

        List<GameObject> temp = NumberPairs[mainBox.GetComponent<BoxHandler>()];
        foreach(GameObject box in temp)
        {
            RectTransform rect= box.GetComponent<RectTransform>();
            Vector2 pos= new Vector2(
                MathF.Floor(rect.anchoredPosition.x/cellSize),
                MathF.Floor(rect.anchoredPosition.y/cellSize)
                );
            boxPositions.Add(pos);
        }

        minX = (int)boxPositions.Min(pos => pos.x);
        minY = (int)boxPositions.Min(pos => pos.y);
        maxX = (int)boxPositions.Max(pos => pos.x);
        maxY = (int)boxPositions.Max (pos => pos.y);

        for(int i=minX;i<=maxX;i++)
        {
            for(int j=minY;j<=maxY;j++)
            {
                
                if(!boxPositions.Contains(new Vector2(i, j)))
                {
                    return false;
                }
                
            }
        }
        return true;
    }
}