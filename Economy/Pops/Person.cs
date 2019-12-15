using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions; 

namespace Pops
{
    public class Person : Iimutable, Irobbable<Person>
    {
        private bool isActive;
        private bool isLogic;

        //Maybe add experience??
        private Job myjob;


        public Person(Job _job)
        {
            myjob = _job;
            isActive = true;
        }

        public Person(Person p, Job _job)
        {
            isActive = p.isActive;
            isLogic = p.isLogic;

            myjob = _job;
        }

        public Job myJob { get { return myjob; } set { myjob = value; } }

        public JobTypesList GetJobType()
        {
            return myjob.JobType;
        }



        /// <summary>
        /// NEEDS TESTING
        /// Change job when full of resources
        /// </summary>
        public void ChangeWhenFull()
        {
            if(myjob.JobType == JobTypesList.Hunter)
            {
                myjob = new Job(JobTypesList.Trader, myjob.actor);
            }
        }

        /// <summary>
        /// Rob this person
        /// </summary>
        /// <param name="obj">Who's stealing from this person</param>
        public void rob(Person obj)
        {
            //Checks if this player is an enemy;
            //if (obj != enemy) return;
            obj.myJob.actor.Stolen(myjob.actor.Steal());
        }
    }
}
