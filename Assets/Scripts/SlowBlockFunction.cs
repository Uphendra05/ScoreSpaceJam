using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBlockFunction : MonoBehaviour
{
    public float slowSpeed;
    public float waitTime;
    public bool isSlowed = false;

    public Material slowBallMaterial;
    public BlockHealth health;

    [ColorUsage(true, true)]
    public Color defaultColor;

    public MeshRenderer meshRenderer;

    public float defaultIntensityMultiplier = 1.5f;
    public float blinkIntensityMultiplier = 1.25f;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log(meshRenderer.material.GetColor("_EmissionColor"));

        meshRenderer.material.SetColor("_EmissionColor", defaultColor * defaultIntensityMultiplier);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("SlowBlock") )
        {
            BallMovement balls = collision.GetComponent<BallMovement>();
            BlinkColor();
            if (!balls.isSlowed)
            {
                balls.isSlowed = true;
            }
            health.healthCount--;

            if (health.healthCount == 0)
            {
                
                GameManager.instance.slowBrickCount++;             


            }

        }
    }

    public void BlinkColor()
    {

        float emissiveIntensity = defaultIntensityMultiplier;


        Timer.Periodic(0.1f, 7, () =>
        {

            if(meshRenderer!=null)
            {
                meshRenderer.material.SetColor("_EmissionColor", defaultColor * emissiveIntensity);
                emissiveIntensity = (emissiveIntensity == defaultIntensityMultiplier) ? blinkIntensityMultiplier : defaultIntensityMultiplier;
            }

            


        });


    }


}
