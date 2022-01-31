using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NormalBlock : MonoBehaviour
{
    public BlockHealth health;

    [ColorUsage(true,true)]
    public Color defaultColor;
    [ColorUsage(true, true)]
    public Color blinkColor;

    public MeshRenderer meshRenderer;

    public float defaultIntensityMultiplier = 1.5f;
    public float blinkIntensityMultiplier = 1.25f;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log(meshRenderer.material.GetColor("_EmissionColor"));

        meshRenderer.material.SetColor("_EmissionColor", defaultColor * defaultIntensityMultiplier);
    }
    void Update()
    {
       
    }
   

   


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("Block") )
        {
            health.healthCount--;
            
            if(meshRenderer!=null)
            {
                BlinkColor();
            }
            else
            {
                Debug.Log("Mesh is destroyed");
            }
              

            

            if (health.healthCount == 0)
            {
               // BlinkColor();
                    GameManager.instance.normalBrickCount++;                
                    
            }
        }
    }

    public void BlinkColor()
    {
       
            float emissiveIntensity = defaultIntensityMultiplier;


            Timer.Periodic(0.1f, 7, () =>
            {

            if (meshRenderer != null)
                {
                    meshRenderer.material.SetColor("_EmissionColor", defaultColor * emissiveIntensity);
                    emissiveIntensity = (emissiveIntensity == defaultIntensityMultiplier) ? blinkIntensityMultiplier : defaultIntensityMultiplier;
                }
               


            });       


    }

   


    //IEnumerator ColorLerp()
    //{

    //}





}
