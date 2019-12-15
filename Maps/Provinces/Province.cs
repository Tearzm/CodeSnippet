using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Map.province
{
    public class Province : ScriptableObject
    {

        private string _ProvinceName;
        private string _Description;

        public string ProvinceName { get; }
        public string Description { get; }

        public virtual void MovedOn() { }
        public virtual void PressedOn() { }
        

    }
}
