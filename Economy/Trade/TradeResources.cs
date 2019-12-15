using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PResources.Trade
{
    public class TradeResources
    {
        public float totalAmount;

        Dictionary<ResourceTypes, int> tradeResource;

        public TradeResources(Dictionary<ResourceTypes, int> _AgreementResources)
        {
            tradeResource = _AgreementResources;
            foreach (var item in tradeResource) totalAmount += item.Value;
        }

        public bool GiveToAMerchant(TradeMerchant m, ResourceActor r)
        {
            Dictionary<ResourceTypes, int> temp = new Dictionary<ResourceTypes, int>();

            //NEEDS CEIL FIX//
            foreach(var item in tradeResource)
            {
                temp.Add(item.Key, ResCalc(item.Value, m.MaxHoldings));
            }
            if (r.Buy(temp))
            {
                m.StartJourney(temp);
                return true;
            }
            return false;
        }

        public void ReceiveFromAMerchant(TradeMerchant m, ResourceActor r)
        {
            r.Stolen(m.reachedJourney());
        }

        private int ResCalc (float _value, float _max)
        {
            if (totalAmount < _max) return (int)_value;
            else
            {
                return Mathf.CeilToInt(((float)_value) / (totalAmount / _max));
            }

        }
    }
}
