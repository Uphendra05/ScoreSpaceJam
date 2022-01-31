using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ball;
   [HideInInspector] public GameObject toBuildPrefab;
    public List<GameObject> allBlockPrefab = new List<GameObject>();
    public int normalBrickCount = 8;
    public int timeBrickCount = 5;
    public int slowBrickCount = 3;


    //public int BrickOneCount = 5;
    //public int BrickTwoCount = 3;
    public int coinCount;
    public int brickOneCostCount = 3;
    public int brickTwoCostCount ;   
    public int ballBounceCountNormal;    
    public int index;
    public int totalBallCount;
    public bool blockOneUnlocked;
    public bool blockTwoUnlocked;
    public AudioSource popAudio;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        toBuildPrefab = allBlockPrefab[0];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
}
