using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public Transform parent;
    void Start()
    {
        parent = transform.parent.transform;
       // transform.localPosition = Vector3.zero;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.parent = parent;
    }

   


}
