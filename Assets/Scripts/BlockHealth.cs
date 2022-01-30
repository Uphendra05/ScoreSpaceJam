using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour
{
    public int healthCount;
    public int maxCount = 3;


    public float timeToLerp = 0.25f;
  
   
    public bool canScale = true;
    public Vector3 targetScale;
    
    void Start()
    {
        healthCount = maxCount;
     
    }

   
    void Update()
    {
        if(healthCount == 0)
        {
            //die;
          
            BlockDie();
        }

        if(canScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, timeToLerp * Time.deltaTime);
        }

        
    }

    public void BlockDie()
    {
        Destroy(this.gameObject,1f);
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            healthCount--;

            if (healthCount == 0)
            {
                GameManager.instance.normalBrickCount++;
            }
        }
    }

}
