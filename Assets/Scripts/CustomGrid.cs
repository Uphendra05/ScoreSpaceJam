using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class CustomGrid : MonoBehaviour
{

    public GameObject target;
    public GameObject structure;
    public Vector3 truePos;
    public float gridSize;

   
    public Transform blockParent;
    public LayerMask raycastLayer;

   public bool canRotate = true;

    public float rotSpeed;

    private void Start()
    {
        //  Cursor.visible = false;
        structure.GetComponent<MeshRenderer>().enabled = false;

    }
    private void Update()
    {
        RaycastHit hit;
      
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,raycastLayer))
        {
            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction*100f,Color.red);
            structure.GetComponent<MeshRenderer>().enabled = true;
            //if(Physics.sphere)
            if (hit.collider.CompareTag("Block")|| EventSystem.current.IsPointerOverGameObject()||hit.collider.CompareTag("SlowBlock")|| hit.collider.CompareTag("TimeBlock"))
            {
                Debug.Log("Block is inbetween");
                structure.GetComponent<MeshRenderer>().enabled = false;
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                canRotate = false;

                structure.transform.position = hit.point;
                structure.transform.Rotate(new Vector3(0, 45, 0));
            }
            
            if(Input.GetMouseButtonUp(1))
            {
                canRotate = true;
                //structure.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }





            if (Input.GetMouseButtonDown(0))
            { 
                if (CheckCube.isAvailable && GameManager.instance.index == 0 || GameManager.instance.index == 1 || GameManager.instance.index == 2)
                {

                    if (GameManager.instance.normalBrickCount>0 && GameManager.instance.index == 0)
                    {
                        GameObject temp = Instantiate(GameManager.instance.toBuildPrefab, new Vector3(structure.transform.position.x, -4.6f, structure.transform.position.z), structure.transform.rotation, blockParent);
                        GameManager.instance.normalBrickCount--;

                    }

                    if (GameManager.instance.timeBrickCount > 0 && GameManager.instance.index == 1)
                    {
                        GameObject temp = Instantiate(GameManager.instance.toBuildPrefab, new Vector3(structure.transform.position.x, -4.6f, structure.transform.position.z), structure.transform.rotation, blockParent);
                        GameManager.instance.timeBrickCount--;
                        //temp.transform.GetChild(1).GetComponent<RotationConstraint>().AddSource(GameManager.instance.rotationSource);
                    }

                    if (GameManager.instance.slowBrickCount > 0 && GameManager.instance.index == 2)
                    {
                        GameObject temp = Instantiate(GameManager.instance.toBuildPrefab, new Vector3(structure.transform.position.x, -4.6f, structure.transform.position.z), structure.transform.rotation, blockParent);
                        GameManager.instance.slowBrickCount--;

                    }



                  
                   



                }
            }   
            //sphere cast
        }
        else
        {
            structure.GetComponent<MeshRenderer>().enabled = false;

        }

        if (canRotate)
        {

            //truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
            //truePos.y = -4.6f;
            //truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

            truePos.x = hit.point.x;
            truePos.y = -4.6f;
            truePos.z = hit.point.z;

            structure.transform.position = truePos;
            
        }



    }

    //private void OnMouseOver()
    //{
    //    Debug.Log("On hovering");
    //    target.transform.position = Input.mousePosition;
    //}

        //private void OnDrawGizmos()
        //{
        //    Vector3 origin = Camera.main.transform.position;
        //    Gizmos.DrawWireSphere(Camera.main.ScreenPointToRay(Input.mousePosition).direction + origin,2f);
      

        //}

}
