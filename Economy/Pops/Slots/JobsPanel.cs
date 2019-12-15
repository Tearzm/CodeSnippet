using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pops;
using Map.building;

public class JobsPanel : MonoBehaviour
{
    //Transform of job slots parent
    [SerializeField] Transform JobSlotsParent;

    //A list of job slots
    [SerializeField] JobSlot[] JobSlots;

    public event Action<Job> OnJobLeftClickEvent;
    

    private void Awake()
    {
        
    }
    
    /// <summary>
    /// Invoke when selecting a major province with a popManager
    /// </summary>
    /// <param name="pops"></param>
    public void OnSelectingAPopManager(Settlement settlement)
    {
        int i = 0;
        
        foreach (DefaultJobContainer job in settlement.availableJobs().AllJobs)
        {
            JobSlots[i].Job = job;
            ///NEEDS FIXING
            JobSlots[i].OnJobLeftClicked += settlement.BuildPop;
            i++;
        }
        JobSlotsParent.gameObject.SetActive(true);
    }

    /// <summary>
    /// Deselcting a pop manager
    /// </summary>
    public void DeselctingAPopManager()
    {
        JobSlotsParent.gameObject.SetActive(false);
    }
}
