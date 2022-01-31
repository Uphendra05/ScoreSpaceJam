using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

   
    void Update()
    {
        levelTimer += Time.deltaTime;


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
                timer.timeStamps.Add(levelTimer - Time.time);
            }
            else
            {
                gameOver.SetActive(true);
                Time.timeScale = 0;

                Debug.Log("Lost");

            }

        }

        if (GameManager.instance.totalBallCount <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;

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
