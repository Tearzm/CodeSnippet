using Pops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobTootip : MonoBehaviour
{
    [Tooltip("How long hover time to show up tooltip")]
    [Range(1, 10)]
    [SerializeField] float WaitToShowToolTip;

    [Space]
    [SerializeField] Text PersonJob;
    //Needs to add job behaviours tooltip


    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = waitToShowTooltip(WaitToShowToolTip);
    }

    /// <summary>
    /// Show a tooltip about this Job
    /// </summary>
    /// <param name="job"></param>
    public void ShowToolTip(DefaultJobContainer job)
    {
        PersonJob.text = job.Job.ToString();

        StartCoroutine(coroutine);
    }

    public void HideTooTip()
    {
        StopCoroutine(coroutine);
        gameObject.SetActive(false);
    }

    private IEnumerator waitToShowTooltip(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(true);
    }

}
