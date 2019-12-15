using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Pops;
using Utils;

public class JobSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Image image;
    [SerializeField] JobTootip tooltip;

    private DefaultJobContainer _job;

    public DefaultJobContainer Job
    {
        get { return _job; }
        set { _job = value; }
    }

    public event Action<JobTypesList> OnJobLeftClicked;

    /// <summary>
    /// Checks for a click on a JobSlot and Invoke the right response
    /// Left clicking a job will start building one
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if(ClickChecker.Click(eventData, MouseButtons.Left))
        {
            if(Job != null && OnJobLeftClicked != null)
            {
                OnJobLeftClicked(Job.Job);
            }
        }
    }

    /// <summary>
    /// Checks if the mouse hovered over a job and shows a tooltip
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(Job);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooTip();
    }

    
}
