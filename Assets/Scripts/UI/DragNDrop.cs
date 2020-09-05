using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform machineTransform; 
    public Canvas dragCanvas;  

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>(); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = machineTransform; 
        canvasGroup.alpha = 0.5f; // make const
        canvasGroup.blocksRaycasts = false; 

        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / dragCanvas.scaleFactor;

        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Raycast will pass through and hit the schedule 
        canvasGroup.blocksRaycasts = true;

        canvasGroup.alpha = 1f; // const 

        //// Return to starting position if not dropped on node 
        //if (gameObject.transform.parent != scheduleContainer.transform)
        //{
        //    gameObject.transform.parent = availableJobsContainer.transform;
        //}

        // need a method for checking if component was dropped on node
        // 

        throw new System.NotImplementedException();
    }
}
