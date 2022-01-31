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
    public Button brickOneButton;
    public Button brickTwoButton;

    public List<pointerScript> buttonScaling = new List<pointerScript>();
    void Start()
    {
        BrickOneBought();
        BrickTwoBought();
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
            if (GameManager.instance.brickOneBought == 1)
            {
                GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];
                GameManager.instance.index = 1;
               
                OnButtonClick(buttonScaling[1]);

            }



        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GameManager.instance.brickTwoBought == 1)
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
            if(GameManager.instance.brickOneBought == 0)
            {
                GameManager.instance.coinCount -= GameManager.instance.brickOneCostCount;
                PlayerPrefs.SetInt("Coins", GameManager.instance.coinCount);

            }

            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            
            GameManager.instance.brickOneBought = 1;
            PlayerPrefs.SetInt("BrickOne", GameManager.instance.brickOneBought);
           

        }



        BrickOneBought();



    }

    public void BlockTwoSelected(Button but)
    {
       
        if (GameManager.instance.coinCount >= GameManager.instance.brickTwoCostCount)
        {
            if (GameManager.instance.brickTwoBought == 0)
            {
                GameManager.instance.coinCount -= GameManager.instance.brickTwoCostCount;
                PlayerPrefs.SetInt("Coins", GameManager.instance.coinCount);

            }

            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            
            GameManager.instance.brickTwoBought = 1;
            PlayerPrefs.SetInt("BrickTwo", GameManager.instance.brickTwoBought);

        }

        BrickTwoBought();

    }


    public void OnButtonClick(pointerScript button)
    {
        for (int i = 0; i < buttonScaling.Count; i++)
        {
           
            buttonScaling[i].SetScale(1);


        }

        button.SetScale(1.5f);
        
    }

    public void BrickOneBought()
    {
        if (GameManager.instance.brickOneBought == 1)
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];
            GameManager.instance.index = 1;
            brickOneButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            timeBlockText.gameObject.SetActive(true);
            timeBlockPrice.SetActive(false);
            OnButtonClick(buttonScaling[1]);

        }
    }

    public void BrickTwoBought()
    {
        if (GameManager.instance.brickTwoBought == 1)
        {

            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[2];
            GameManager.instance.index = 2;
            brickTwoButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            slowBlockText.gameObject.SetActive(true);
            slowBlockPrice.SetActive(false);
            OnButtonClick(buttonScaling[2]);


        }

    }



    }
