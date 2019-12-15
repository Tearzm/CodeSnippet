using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.building;

namespace PResources.Trade
{
    public class TradeSystem
    {
        private Settlement FirstSettlement;
        private Settlement SecondSettlement;

        private float MaximumMerchantHold;
        private int MaximumMerchants;

        List<TradeAgreement> tradeAgreements;

        public List<TradeAgreement> initiatedAgreements;


        // A list of all merchants that are currently working in this trade route
        public Dictionary<TradeMerchant, TradeAgreement> merchants;

        public TradeSystem(Settlement s1, Settlement s2)
        {
            FirstSettlement = s1;
            SecondSettlement = s2;

            //Remember to read from editor to change
            MaximumMerchantHold = 50;
            MaximumMerchants = 20;

            initiatedAgreements = new List<TradeAgreement>();
            tradeAgreements = new List<TradeAgreement>();
            merchants = new Dictionary<TradeMerchant, TradeAgreement>();
        }

        public TradeSystem(Settlement s1, Settlement s2, float maximumMerchantHold, int maximumMerchants) : this(s1, s2)
        {
            MaximumMerchantHold = maximumMerchantHold;
            MaximumMerchants = maximumMerchants;
        }


        /// <summary>
        /// Initiate a trade agreement between these two settlements
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        public void InitiateAgreement(Dictionary<ResourceTypes, int> r1, Dictionary<ResourceTypes, int> r2)
        {
            initiatedAgreements.Add(new TradeAgreement(FirstSettlement.settlementResources, SecondSettlement.settlementResources, r1, r2));
        }

        /// <summary>
        /// Refuse an initiated agreement from the other settlement
        /// </summary>
        /// <param name="t"></param>
        public void RefuseAgreement(TradeAgreement t)
        {
            initiatedAgreements.Remove(t);
        }
        
        /// <summary>
        /// Accept an agreement and inistantiate a set of merchants to travel between agreement holders
        /// </summary>
        /// <param name="temp"></param>
        public void AddAgreement(TradeAgreement temp)
        {
            initiatedAgreements.Remove(temp);
            int merchantNumber = merchantNumberCalc(temp.firstSettlementResources.totalAmount, temp.SecondSettlementResources.totalAmount);
            if (merchants.Count + merchantNumber > MaximumMerchants) return;

            for (int i = 0; i < merchantNumber; i++)
            {
                merchants.Add(new TradeMerchant(MaximumMerchantHold), temp);
            }
            tradeAgreements.Add(temp);
        }


        /// <summary>
        /// Useless for now
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        public void AddAgreement(Dictionary<ResourceTypes, int> r1, Dictionary<ResourceTypes, int> r2)
        {
            TradeAgreement temp = new TradeAgreement(FirstSettlement.settlementResources, SecondSettlement.settlementResources, r1, r2);
            int merchantNumber = merchantNumberCalc(temp.firstSettlementResources.totalAmount, temp.SecondSettlementResources.totalAmount);
            if (merchants.Count + merchantNumber > MaximumMerchants) return;

            for(int i = 0; i < merchantNumber; i++)
            {
                merchants.Add(new TradeMerchant(MaximumMerchantHold), temp);
            }
            tradeAgreements.Add(temp);
        }


        /// <summary>
        /// Stop a currently working agreement
        /// </summary>
        /// <param name="tradeAgreement"></param>
        private void DeleteAgreement(TradeAgreement tradeAgreement)
        {
            tradeAgreements.Remove(tradeAgreement);
            foreach (var merchant in merchants)
            {
                if (tradeAgreement == merchant.Value) merchant.Key.merchantState = TradeMerchant.MerchantState.ChangedWork;
            }
        }

        private int merchantNumberCalc(float s1, float s2)
        {
            return Mathf.CeilToInt((Mathf.Max(s1, s2)) / MaximumMerchantHold);
        }

        private void PassTurn()
        {
            foreach (var merchant in merchants)
            {
                if (merchant.Key.merchantState == TradeMerchant.MerchantState.ReadyToDismiss)
                    merchants.Remove(merchant.Key);
            }
            foreach(var agreement in tradeAgreements)
            {
                agreement.PassTurn();
            }
        }

        /// <summary>
        /// Get which settlement this is
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool mySettlment(Settlement s)
        {
            if (FirstSettlement == s) return false;
            else return true;
        }
    }
}
