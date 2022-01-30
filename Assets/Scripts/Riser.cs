using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour
{
    public float randomOffset;
    void Start()
    {
        randomOffset = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.PerlinNoise(transform.position.x, transform.position.y) ;
        transform.localScale = new Vector3(0.4f, (Mathf.Sin(Time.time) * randomOffset + 0.5f), 0.4f);
    }
}
