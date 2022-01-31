using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class pointerScript : MonoBehaviour
{




    public void SetScale(float scale)
    {
        transform.DOScale(scale, 0.5f);
       // transform.localScale = Vector3.one * scale;

    }

    [ContextMenu("ScaleButton")]
    public void SetDefault()
    {
        SetScale(1.5f);

    }
    
}
