using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.building;

namespace PResources.Trade
{
    public class TradeAgreement
    {
        private ResourceActor FirstSettlement;
        private ResourceActor SecondSettlement;

        public TradeResources firstSettlementResources;
        public TradeResources SecondSettlementResources;

        
        List<TradeMerchant> onHoldMerchants;


        public TradeAgreement(ResourceActor firstSettlement, ResourceActor secondSettlement, Dictionary<ResourceTypes, int> r1, Dictionary<ResourceTypes, int> r2)
        {
            FirstSettlement = firstSettlement;
            SecondSettlement = secondSettlement;
            firstSettlementResources = new TradeResources(r1);
            SecondSettlementResources = new TradeResources(r2);
            onHoldMerchants = new List<TradeMerchant>();
            
        }

        public void merchantReachedSettlement(int SettlementNum, TradeMerchant myMerchant)
        {
            
            if(SettlementNum == 0)
            {
                firstSettlementResources.ReceiveFromAMerchant(myMerchant, FirstSettlement);
                //FirstSettlement.Stolen(myMerchant.reachedJourney());
                if(ReadyToDismassMerchant(myMerchant)) { }
                else if (!firstSettlementResources.GiveToAMerchant(myMerchant, FirstSettlement)) onHoldMerchants.Add(myMerchant);
            }
            else
            {
                SecondSettlementResources.ReceiveFromAMerchant(myMerchant, SecondSettlement);
                //SecondSettlement.Stolen(myMerchant.reachedJourney());
                if (ReadyToDismassMerchant(myMerchant)) { }
                else if (!SecondSettlementResources.GiveToAMerchant(myMerchant, SecondSettlement)) onHoldMerchants.Add(myMerchant);
            }
        }


        public void PassTurn()
        {
            for(int i = onHoldMerchants.Count - 1; i >= 0; i--)
            {
                if (onHoldMerchants[i].Dist == 1) firstSettlementResources.GiveToAMerchant(onHoldMerchants[i], FirstSettlement);
                else SecondSettlementResources.GiveToAMerchant(onHoldMerchants[i], SecondSettlement);
            }
        }

        private bool ReadyToDismassMerchant(TradeMerchant tradeMerchant)
        {
            if (tradeMerchant.merchantState == TradeMerchant.MerchantState.ChangedWork)
            {
                tradeMerchant.merchantState = TradeMerchant.MerchantState.ReadyToDismiss;
                return true;
            }
            return false;
        }
    }
}
