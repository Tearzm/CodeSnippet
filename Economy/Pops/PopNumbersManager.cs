using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pops
{
    public class PopNumbersManager
    {
        private int _MaxPops;
        private int _PopNum;

        public int MaxPops { get { return _MaxPops; } }
        public int PopNum { get { return _PopNum; } }

        public PopNumbersManager()
        {
            _MaxPops = 10000;
            _PopNum = 0;
        }

        public PopNumbersManager(int _max)
        {
            _MaxPops = _max;
        }

        public bool CheckIfCanBuild()
        {
            if (_PopNum < _MaxPops) return true;
            return false;
        }

        public bool AddAPop()
        {
            if (!CheckIfCanBuild()) return false;
            _PopNum++;
            return true;
        }

        public void KillAPop()
        {
            _PopNum--;
        }
    }
}
