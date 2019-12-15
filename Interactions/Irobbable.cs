using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public interface Irobbable<T>
    {
        void rob(T obj);
    }
}
