using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;

namespace Pops
{
    [System.Serializable]
    public class DefaultJobContainer
    {
        [SerializeField]
        private JobTypesList job;

        [SerializeField]
        public ResourceBehaviour Cost;

        [SerializeField]
        private int TrainingTime;

        [Space]
        [SerializeField]
        public ResourceHolderInitializer ResourceHolder;
        [SerializeField]
        public List<ResourceBehaviour> Upkeep;

        public JobTypesList Job { get { return job; } }

        public int TrainTime()
        {
            return TrainingTime;
        }

    }
}
