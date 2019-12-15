using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PResources;
using System;

public class ResourceTooltip : MonoBehaviour
{

    [Tooltip("How long hover time to show up tooltip")]
    [Range(1, 10)]
    [SerializeField] float WaitToShowToolTip;

    [Space]
    [SerializeField] Text ResourceName;
    [SerializeField] Text ResourceDescription;

    [Space]
    [SerializeField] Text AdditiveBehaviours;
    [SerializeField] Text SubtractiveBehaviours;
    //Needs to add job behaviours tooltip

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = waitToShowTooltip(WaitToShowToolTip);
    }


    public void ShowToolTip(PResources.Resource resource, string ResourceType)
    {
        ResourceName.text = ResourceType;
        ResourceDescription.text = (string)(Enum.Parse(typeof(ResourceTypes), ResourceType));

        AdditiveBehaviours.text = ((int)resource.GetTicks(TickTypes.Additive)).ToString();
        SubtractiveBehaviours.text = ((int)resource.GetTicks(TickTypes.Subtractive)).ToString();

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
