using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

    public int brickOneBought;
    public int brickTwoBought;
    public GameObject rotationConstraint;
    public ConstraintSource rotationSource;
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
        if(PlayerPrefs.HasKey("Coins"))
        {
            coinCount = PlayerPrefs.GetInt("Coins");
        }

        if (PlayerPrefs.HasKey("BrickOne"))
        {
            brickOneBought = PlayerPrefs.GetInt("BrickOne");
        }

        if (PlayerPrefs.HasKey("BrickTwo"))
        {
            brickTwoBought = PlayerPrefs.GetInt("BrickTwo");
        }

        
        rotationSource.sourceTransform = rotationConstraint.transform;
        rotationSource.weight = 1;


    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
}
