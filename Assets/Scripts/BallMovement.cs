using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    public LayerMask collisonMask;
    public int bounceCount;

    public float timeToLerp = 0.25f;
    public bool canScale = true;
    public Vector3 targetScale;

    void Start()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, Random.Range(0, 360), transform.rotation.z);
    }

    private void Update()
    {

        if (canScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, timeToLerp * Time.deltaTime);


        }
    }

    void FixedUpdate()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit ,Time.deltaTime*speed + 0.1f, collisonMask))
        {
            
            Vector3 reflectRay = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectRay.z, reflectRay.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Block"))
        {
          
            bounceCount--;
            GameManager.instance.ballBounceCountNormal++;

            if (bounceCount == 0)
            {
                bounceCount = 3;

                var collisionPoint = other.ClosestPoint(transform.position);
                var collisionNormal = transform.position - collisionPoint;
                Vector3 dir = Vector3.Normalize(collisionPoint - transform.position);
                Vector3 reflectRay = Vector3.Reflect(dir, collisionNormal);
                float rot = 90 - Mathf.Atan2(reflectRay.z, reflectRay.x) * Mathf.Rad2Deg;               
                Instantiate(GameManager.instance.ball, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y * rot, transform.rotation.z));

            }
        }
    }
    

}
