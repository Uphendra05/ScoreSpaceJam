using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public int column, row; 
    public float xSpace, ySpace; 
    public GameObject prefab;
    public float xstart, ystart;

    void Start() 
    { 
        gridSpawner();
    }

    void Update() 
    {

    }

    [ContextMenu("sPaWnEr")]
    public void gridSpawner()
    {
        if (this.transform.childCount!=0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            for (int i = 0; i < column * row; i++)
            {
                Instantiate(prefab, new Vector3(xstart + (xSpace * (i % column)), 0, ystart + (-ySpace * (i / column))), Quaternion.identity, this.gameObject.transform);
            }
        }
       
    }
}
