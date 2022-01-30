using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float inputX;
    public Animator anim;

    public float turnSpeed;

    Vector2 input;
    float angle;

    Quaternion targetRot;
    
    public float targetScale;
    public float targetScale2;

    public float timeToLerp = 0.25f;
    public float scaleModifier = 1;
    public float scaleModifier2 = 0.1f;
    public GameObject shield;
    public bool canShield;

    void Update()
    {


        input.x = Input.GetAxisRaw("Horizontal");
        Quaternion rotateAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, input.x * speed );
        transform.Rotate(rotateAngle.eulerAngles);

        if(input.x > 0 || input.x <0)
        {
            Direction();
            RotatePlayer();
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canShield == false)
            {
                StartCoroutine(LerpFunction(targetScale, timeToLerp));
            }
           
          
        }
       



    }


    public void Direction()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle +90f;       
       
    }

    public void RotatePlayer()
    {
        targetRot = Quaternion.Euler(transform.GetChild(0).gameObject.transform.localRotation.x, angle , transform.GetChild(0).gameObject.transform.localRotation.z);
        targetRot = targetRot.normalized;
        transform.GetChild(0).gameObject.transform.localRotation = Quaternion.Slerp(transform.GetChild(0).gameObject.transform.localRotation, targetRot , turnSpeed * Time.deltaTime);
    }



    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = shield.transform.localScale;
        yield return new WaitForSeconds(0.1f);
        shield.GetComponent<MeshRenderer>().enabled = true;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            shield.transform.localScale = new Vector3(startScale.x * scaleModifier, shield.transform.localScale.z, shield.transform.localScale.z);
            time += Time.deltaTime;
            canShield = true;
            yield return null;
        }
        shield.transform.localScale = new Vector3(startScale.x * scaleModifier, shield.transform.localScale.z, shield.transform.localScale.z);
        scaleModifier = 1;
        yield return new WaitForSeconds(1f);
        //shield.transform.localScale = new Vector3(0.1f, 1, 1);
        StartCoroutine(LerpFunction2(0.1f, timeToLerp));
        shield.GetComponent<MeshRenderer>().enabled = false;
        canShield = false;

    }

    IEnumerator LerpFunction2(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier2;
        Vector3 startScale = shield.transform.localScale;
       
        while (time < duration)
        {
            scaleModifier2 = Mathf.Lerp(startValue, endValue, time / duration);
            shield.transform.localScale = new Vector3(startScale.x * scaleModifier2, shield.transform.localScale.z, shield.transform.localScale.z);
            time += Time.deltaTime;          
            yield return null;
        }
        shield.transform.localScale = new Vector3(startScale.x * scaleModifier2, shield.transform.localScale.z, shield.transform.localScale.z);
        scaleModifier2 = 1f;
        

    }






}
