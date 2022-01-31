using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Image blockImage;
    public Text normalBlockText;
    public Text timeBlockText;
    public Text slowBlockText;
    public Text coinCountText;
    public Text ballCountText;
    public Text objectiveText;

    
    public GameObject timeBlockPrice;
    public GameObject slowBlockPrice;

    public PointerEventData data;
    public LevelManager level;

    public List<pointerScript> buttonScaling = new List<pointerScript>();
    void Start()
    {
        NormalBlockSelected();


    }

    
    void Update()
    {

        normalBlockText.text = GameManager.instance.normalBrickCount.ToString();
        timeBlockText.text = GameManager.instance.timeBrickCount.ToString();
        slowBlockText.text = GameManager.instance.slowBrickCount.ToString();
        coinCountText.text = GameManager.instance.coinCount.ToString();
        ballCountText.text = GameManager.instance.totalBallCount.ToString();
        objectiveText.text = level.objectiveCount.ToString();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[0];
            GameManager.instance.index = 0;
           
            OnButtonClick(buttonScaling[0]);


        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GameManager.instance.blockOneUnlocked == true)
            {
                GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];
                GameManager.instance.index = 1;
               
                OnButtonClick(buttonScaling[1]);

            }



        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GameManager.instance.blockTwoUnlocked == true)
            {
                GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[2];
                GameManager.instance.index = 2;
                
                OnButtonClick(buttonScaling[2]);

            }

        }




    }
    public void NormalBlockSelected()
    {
       


        
        GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[0];
        GameManager.instance.index = 0;
        OnButtonClick(buttonScaling[0]);


    }

    public void BlockOneSelected(Button but)
    {
        

      
        if (GameManager.instance.coinCount >= GameManager.instance.brickOneCostCount)
        {
            if(GameManager.instance.blockOneUnlocked ==false)
            GameManager.instance.coinCount -= GameManager.instance.brickOneCostCount;

            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameManager.instance.blockOneUnlocked = true;
        }
        

        if (GameManager.instance.blockOneUnlocked == true)
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];
            GameManager.instance.index = 1;
           
            timeBlockText.gameObject.SetActive(true);
            timeBlockPrice.SetActive(false);
            OnButtonClick(buttonScaling[1]);

        }


       
    }

    public void BlockTwoSelected(Button but)
    {
       
        if (GameManager.instance.coinCount >= GameManager.instance.brickTwoCostCount)
        {
            if (GameManager.instance.blockTwoUnlocked == false)
                GameManager.instance.coinCount -= GameManager.instance.brickTwoCostCount;

            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameManager.instance.blockTwoUnlocked = true;
            
        }

        if (GameManager.instance.blockTwoUnlocked == true)
        {
            
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[2];
            GameManager.instance.index = 2;
         
            slowBlockText.gameObject.SetActive(true);
            slowBlockPrice.SetActive(false);
            OnButtonClick(buttonScaling[2]);


        }

    }


    public void OnButtonClick(pointerScript button)
    {
        for (int i = 0; i < buttonScaling.Count; i++)
        {
           
            buttonScaling[i].SetScale(1);


        }

        button.SetScale(1.5f);
        
    }


  


}
