using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.province
{
    public class NaturalFeatures : Province, IHoverable
    {
        [SerializeField]
        private NaturalFeaturesList Type;

        

        //[SerializeField]
        //private <List>Debuffs debuffs;

        public override void MovedOn()
        {
            //Apply Buffs
        }

        public override void PressedOn()
        {
            //Show Details about this province
        }
        

        public string HoveredText { get; set; }

    }
}
