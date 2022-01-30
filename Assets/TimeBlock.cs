using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlock : MonoBehaviour
{
    public float timeBlockTimer;
    public float timeToLerp = 0.25f;


    public bool canScale = true;
    public Vector3 targetScale;
    void Update()
    {
        timeBlockTimer -= Time.deltaTime;

        if(timeBlockTimer <= 0)
        {
            Destroy(this.gameObject);
        }


        if (canScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, timeToLerp * Time.deltaTime);
        }

    }
}
