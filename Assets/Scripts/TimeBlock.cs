using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBlock : MonoBehaviour
{
    public float timeBlockTimer;
    public float timeToLerp = 0.25f;
    public bool canScale = true;
    public Vector3 targetScale;
    public bool isDestroyed;

    [ColorUsage(true, true)]
    public Color defaultColor;

    public MeshRenderer meshRenderer;

    public float defaultIntensityMultiplier = 1.5f;
    public float blinkIntensityMultiplier = 1.25f;

    

    private void Start()
    {
        isDestroyed = true;
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log(meshRenderer.material.GetColor("_EmissionColor"));

        meshRenderer.material.SetColor("_EmissionColor", defaultColor * defaultIntensityMultiplier);
    }
    void Update()
    {
        timeBlockTimer -= Time.deltaTime;

        if(timeBlockTimer <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject,0.5f);

            if(isDestroyed)
            {
                GameManager.instance.timeBrickCount++;
                BlinkColor();
                isDestroyed = false;
            }
           

        }


        if (canScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, timeToLerp * Time.deltaTime);
        }

    }




    public void BlinkColor()
    {

        float emissiveIntensity = defaultIntensityMultiplier;


        Timer.Periodic(0.1f, 7, () =>
        {


            meshRenderer.material.SetColor("_EmissionColor", defaultColor * emissiveIntensity);
            emissiveIntensity = (emissiveIntensity == defaultIntensityMultiplier) ? blinkIntensityMultiplier : defaultIntensityMultiplier;


        });


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("TimeBlock"))
        {
           
            BlinkColor();
            

        }
    }

}
