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
    //public int BrickOneCount = 5;
    //public int BrickTwoCount = 3;
    public int coinCount;
    public int brickOneCostCount = 3;
    public int brickTwoCostCount ;

    public bool blockOneUnlocked;
    public bool blockTwoUnlocked;

    public int ballBounceCountNormal;



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

        if(ballBounceCountNormal >= 10)
        {
            allBlockPrefab[0].GetComponent<BlockHealth>().maxCount = 6;

        }
        
    }
}
