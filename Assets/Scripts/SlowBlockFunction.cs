using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBlockFunction : MonoBehaviour
{
    public float slowSpeed;
    public float waitTime;
    public bool isSlowed = false;

    public Material slowBallMaterial;

   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallMovement balls = collision.GetComponent<BallMovement>();
            if(!balls.isSlowed)
            {
                balls.isSlowed = true;
            }
           
        }
    }

    //IEnumerator SlowFunction(BallMovement ball, float timer)
    //{
    //    float currentSpeed = 6;
    //    ball.speed = slowSpeed;

    //    Material defaultMat = ball.GetComponent<MeshRenderer>().material;
    //    ball.GetComponent<MeshRenderer>().material = slowBallMaterial;

    //    yield return new WaitForSeconds(timer);

    //    ball.speed = currentSpeed;
    //    ball.GetComponent<MeshRenderer>().material = defaultMat;
    //}
}
