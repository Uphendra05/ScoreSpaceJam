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

    public GameObject normalBlockArrow;
    public GameObject timeBlockArrow;
    public GameObject slowBlockArrow;
    public PointerEventData data;
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

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[0];
            GameManager.instance.index = 0;
            normalBlockArrow.gameObject.SetActive(true);
            timeBlockArrow.gameObject.SetActive(false);
            slowBlockArrow.gameObject.SetActive(false);


        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GameManager.instance.blockOneUnlocked == true)
            {
                GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];
                GameManager.instance.index = 1;
                normalBlockArrow.gameObject.SetActive(false);
                timeBlockArrow.gameObject.SetActive(true);
                slowBlockArrow.gameObject.SetActive(false);

            }



        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GameManager.instance.blockTwoUnlocked == true)
            {
                GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[2];
                GameManager.instance.index = 2;
                normalBlockArrow.gameObject.SetActive(false);
                timeBlockArrow.gameObject.SetActive(false);
                slowBlockArrow.gameObject.SetActive(true);

            }

        }




    }
    public void NormalBlockSelected()
    {
       


        
        GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[0];
        GameManager.instance.index = 0;
        normalBlockArrow.gameObject.SetActive(true);
        timeBlockArrow.gameObject.SetActive(false);
        slowBlockArrow.gameObject.SetActive(false);

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
            normalBlockArrow.gameObject.SetActive(false);
            timeBlockArrow.gameObject.SetActive(true);
            slowBlockArrow.gameObject.SetActive(false);

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
            normalBlockArrow.gameObject.SetActive(false);
            timeBlockArrow.gameObject.SetActive(false);
            slowBlockArrow.gameObject.SetActive(true);

        }     

    }


  


}
