using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointerScript : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{

    public RectTransform button;

    private void Start()
    {
            button.GetComponent<Animator>().SetBool("isScaleUp", false);

    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
               
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            button.GetComponent<Animator>().SetBool("isScaleUp", true);
        }
    }

    

    public void OnPointerExit(PointerEventData pointerEventData)
    {   
            button.GetComponent<Animator>().SetBool("isScaleUp", false);
        
    }
}
