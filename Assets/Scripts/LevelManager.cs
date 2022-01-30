using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int objectiveCount;
    public float waitTime;
    public bool isComplete;
    void Start()
    {
        isComplete = false;
    }

   
    void Update()
    {
        if(GameManager.instance.totalBallCount >= objectiveCount)
        {
            StartGame();

        }


        if(isComplete)
        {
            if (GameManager.instance.totalBallCount >= objectiveCount)
            {
                Debug.Log("Win Game");
            }
            else
            {
                Debug.Log("Lost");
            }

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
            waitTime -= Time.deltaTime;

        }


    }
}
