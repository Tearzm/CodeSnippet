using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Map.province;
using Utils;
using System;

/// <summary>
/// A monobehaviour class that contains a province
/// </summary>
public class ProvinceSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] GameObject myProvinceTile;
    /// <summary>
    /// A monobehaviour that holds any UI to show tooltip
    /// </summary>
    [SerializeField] ProvinceTooltip provinceTooltip;

    /// <summary>
    /// A job panel that gets triggered when this province is selected
    /// </summary>
    [SerializeField] JobsPanel jobPanel;

    /// <summary>
    /// Selecting a Major Province
    /// </summary>
    public event Action<PopsManager> OnSelectingAPopManager;

    private Province _province;
    public Province Province
    {
        get { return _province; }
        set { _province = value; }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(ClickChecker.Click(eventData, MouseButtons.Left))
        {
            if(Province != null && (Province is MajorProvince))
            {
                MajorProvinceClicked((MajorProvince)Province);
            }
        }
    }


    /// <summary>
    /// If a major province is selected
    /// </summary>
    /// <param name="majorProvince"></param>
    private void MajorProvinceClicked(MajorProvince majorProvince)
    {
        if(majorProvince.Settlement != null)
        {
            jobPanel.OnSelectingAPopManager(majorProvince.Settlement);
        }
    }

    /// <summary>
    /// Called when the mouse hovers over a province to show a tool tip about it
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Province is MajorProvince)
        {
            provinceTooltip.ShowToolTip((MajorProvince)Province);
        }
    }

    /// <summary>
    /// Called when a mouse leaves a province to hide its tooltip
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        provinceTooltip.HideToolTip();
    }
}
