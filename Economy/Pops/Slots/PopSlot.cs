using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Pops;
using System;

public class PopSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Image image;
    [SerializeField] PersonTooltip tooltip;

    public event Action<Person> OnPersonLeftClicked;

    private Person _person;

    public Person Person
    {
        get { return _person; }
        set { _person = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(Person);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooTip();
    }
}
