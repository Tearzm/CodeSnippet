using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PResources.Trade
{
    public class TradeMerchant
    {
        public float MaxHoldings;
        public bool OnHold;
        public enum MerchantState
        {
            Working,
            ChangedWork,
            ReadyToDismiss,
        }
        public MerchantState merchantState;
        public int Dist;

        private ResourceActor merchantHoldings;

        public TradeMerchant()
        {
            merchantHoldings = new ResourceActor(true);
            OnHold = false;
            merchantState = MerchantState.Working;
            Dist = 1;
            MaxHoldings = 2<<31;
        }

        public TradeMerchant(float _MaxHoldings)
        {
            merchantHoldings = new ResourceActor(true);
            MaxHoldings = _MaxHoldings;
            Dist = 1;
            OnHold = false;
            merchantState = MerchantState.Working;
        }


        public void StartJourney(Dictionary<ResourceTypes, int> r)
        {
            ToggleDist();
            merchantHoldings.AddResources(r);
        }

        public ResourceHolder reachedJourney()
        {
            return merchantHoldings.Steal();
        }

        public ResourceHolder raid()
        {
            ToggleDist();
            return merchantHoldings.Steal();
        }

        private void ToggleDist()
        {
            if (Dist == 0) Dist = 1;
            else Dist = 0;
        }

    }
}
