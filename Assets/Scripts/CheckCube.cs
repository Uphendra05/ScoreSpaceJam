using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCube : MonoBehaviour
{
    public static bool isAvailable = true;

    public Material defaultMat;
    public Material blockMat;

    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.CompareTag("Brick"))
        {
            isAvailable = false;
            GetComponent<MeshRenderer>().material = blockMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.CompareTag("Brick"))
        {
            isAvailable = true;
            GetComponent<MeshRenderer>().material = defaultMat;
        }
    }
}
