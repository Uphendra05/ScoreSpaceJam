using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image CoolDownImage;
    public Text normalBlockText;
    public Text coinCountText;
    public Image barFillImage;

    void Start()
    {
        
    }

    
    void Update()
    {

        normalBlockText.text = GameManager.instance.normalBrickCount.ToString();
        coinCountText.text = GameManager.instance.coinCount.ToString();

        
        barFillImage.fillAmount = Mathf.Lerp(0, (float) GameManager.instance.ballBounceCountNormal/10, 1f) ;

        
    }
    public void NormalBlockSelected()
    {
       
        GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[0];

    }

    public void BlockOneSelected(Button but)
    {
        
        if(GameManager.instance.coinCount >= GameManager.instance.brickOneCostCount)
        {
            GameManager.instance.coinCount -= GameManager.instance.brickOneCostCount;
            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameManager.instance.blockOneUnlocked = true;
        }
        

        if (GameManager.instance.blockOneUnlocked == true)
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[1];

        }



    }

    public void BlockTwoSelected(Button but)
    {
        if (GameManager.instance.coinCount >= GameManager.instance.brickTwoCostCount)
        {
            GameManager.instance.coinCount -= GameManager.instance.brickTwoCostCount;
            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameManager.instance.blockTwoUnlocked = true;
            
        }

        if (GameManager.instance.blockTwoUnlocked == true)
        {
            GameManager.instance.toBuildPrefab = GameManager.instance.allBlockPrefab[2];

        }



    }


}
