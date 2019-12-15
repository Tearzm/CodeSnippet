using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Map.building;
using Map.province;

public class ProvinceTooltip : MonoBehaviour
{
    [SerializeField] Text ProvinceName;
    [SerializeField] Text ProvinceType;
    [SerializeField] Text ProvinceOwner;


    /// <summary>
    /// Shows a tooltip for a major province
    /// </summary>
    /// <param name="province"></param>
    public void ShowToolTip(MajorProvince province)
    {
        if(province.Settlement != null)
        {
            ProvinceName.text = province.Settlement.SettlementName;
            ProvinceType.text = province.Settlement.SettlementDescription;
            ProvinceOwner.text = province.Owner;
        }
        else
        {
            ProvinceName.text = province.ProvinceName;
            ProvinceType.text = province.Description;
            ProvinceOwner.text = "Unoccupied";
        }
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides this tooltip
    /// </summary>
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
