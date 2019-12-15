using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.province {
    public class MinorProvince : Province, IHoverable
    {
        
        //private Structure structure


        public override void MovedOn()
        {
            //Claim or do something
        }

        public override void PressedOn()
        {
            //Show Details about this province
        }

        public string HoveredText { get; set; }
    }
}
