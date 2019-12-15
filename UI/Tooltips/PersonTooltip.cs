using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pops;

public class PersonTooltip : MonoBehaviour
{
    [Tooltip("How long hover time to show up tooltip")]
    [Range(1,10)]
    [SerializeField] float WaitToShowToolTip;

    [Space]
    [SerializeField] Text PersonJob;
    //Needs to add person resource tool tip


    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = waitToShowTooltip(WaitToShowToolTip);
    }

    public void ShowToolTip(Person person)
    {
        PersonJob.text = person.myJob.JobType.ToString();
        
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
