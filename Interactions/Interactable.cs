using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interactions
{
    public interface Interactable<T> where T : Pops.Person
    {
        void EnterRegion(T obj);
        void EnterSettlement(T obj);
        void LeaveRegion(T obj);
    }
}
