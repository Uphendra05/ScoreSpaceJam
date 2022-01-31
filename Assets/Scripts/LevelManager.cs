using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int objectiveCount;
    public float waitTime;
    public bool isComplete;
    public Text timerText;
    public GameObject gameWon;
    public GameObject gameOver;
    public bool timerStart;

    public LevelTimer timer;
    public float levelTimer;

    void Start()
    {
        isComplete = false;
        Time.timeScale = 1;

    }


    void Update()
    {
       


        if(GameManager.instance.totalBallCount >= objectiveCount)
        {
            timerStart = true;

        }

        if(timerStart)
        {
            StartGame();

        }

        if (isComplete)
        {
            if (GameManager.instance.totalBallCount >= objectiveCount)
            {
                gameWon.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Win Game");
                if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }    
               

            }
            else
            {
                gameOver.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("Level 1");

                }
                //  SceneManager.LoadScene(load from first);
                Debug.Log("Lost");

            }

        }

        if (GameManager.instance.totalBallCount <= 0)
        {
            gameOver.SetActive(true);
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level 1");

            }
            Debug.Log("Lost Game");
           
        }

    }

    public void StartGame()
    {

        if(waitTime<=0)
        {
           isComplete = true;

        }
        else
        {
            timerText.text = waitTime.ToString("0.00");
            waitTime -= Time.deltaTime;

        }


    }
}
