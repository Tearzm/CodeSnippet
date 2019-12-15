using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.building;

namespace Map.province {
    public class MajorProvince : Province, IHoverable
    {

        private Settlement _settlement;

        public Settlement Settlement
        {
            get { return _settlement; }
            
        }

        /// <summary>
        /// Change to private later
        /// </summary>
        public string Owner;

        public override void MovedOn()
        {
            //Do stuff
        }

        public override void PressedOn()
        {
            //Show Details about this province
        }

        

        public string HoveredText { get; set; }

    }
}
