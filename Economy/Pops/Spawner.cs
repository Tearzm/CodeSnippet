using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;


namespace Pops
{

    public class Spawner
    {
        private string EmpireName;

        //Needs to be changed to private Settlement;
        private ResourceActor Settlement;

        [SerializeField]
        private DefaultJobs defaultJobs;

        [SerializeField]
        private PopNumbersManager popNumbersManager;

        private List<CurrentlyBuildingJobs> CurrentlyBuildingJobs;

        public Spawner(DefaultJobs _defaultJobs)
        {
            defaultJobs = _defaultJobs;
            popNumbersManager = new PopNumbersManager(10);
            CurrentlyBuildingJobs = new List<CurrentlyBuildingJobs>();
        }

        public Spawner(DefaultJobs _defaultJobs, ResourceActor actor)
        {
            defaultJobs = _defaultJobs;
            Settlement = actor;
            popNumbersManager = new PopNumbersManager(10);
            CurrentlyBuildingJobs = new List<CurrentlyBuildingJobs>();
        }


        public Spawner(DefaultJobs _defaultJobs, ResourceActor actor, int MaxPop)
        {
            defaultJobs = _defaultJobs;
            Settlement = actor;
            popNumbersManager = new PopNumbersManager(MaxPop);
            CurrentlyBuildingJobs = new List<CurrentlyBuildingJobs>();
        }

        public bool AddPop(JobTypesList _type)
        {
            CurrentlyBuildingJobs j = new CurrentlyBuildingJobs(defaultJobs.GetJob(_type));
            if (j == null || (!popNumbersManager.AddAPop())) return false;

            //Needs checking for special cases later
            CurrentlyBuildingJobs.Add(j);
            sortCurrentJobs();
            return true;
        }

        public DefaultJobs availabeJobs()
        {
            return defaultJobs;
        }

        private void sortCurrentJobs()
        {
            CurrentlyBuildingJobs.Sort(CompareRemainingJobOrder);
        }

        public List<Person> PassTurn()
        {
            List<Person> people = new List<Person>();
            for(int i = CurrentlyBuildingJobs.Count - 1; i >= 0; i--)
            {
                CurrentlyBuildingJobs[i].PassTurn();
                if (CurrentlyBuildingJobs[i].RemainingTime == 0)
                {
                    ResourceActor r = new ResourceActor(CurrentlyBuildingJobs[i].GetResourceHolder(), CurrentlyBuildingJobs[i].GetResourceBehaviours());
                    Job temp = new Job(CurrentlyBuildingJobs[i].GetJob(), r);
                    if (CurrentlyBuildingJobs[i].CurrentPerson != null)
                    {
                        people.Add(new Person(CurrentlyBuildingJobs[i].CurrentPerson, temp));
                    }
                    else { people.Add(new Person(temp)); }
                    CurrentlyBuildingJobs.RemoveAt(i);
                }  
            }
            return people;
        }

        public void AddJobs(DefaultJobs newJobs)
        {
            defaultJobs.AddJobsToList(newJobs);
        }

        public int getPopulation()
        {
            return popNumbersManager.PopNum;
        }

        public int getMaxPopulation()
        {
            return popNumbersManager.MaxPops;
        }

        protected int CompareRemainingJobOrder(CurrentlyBuildingJobs a, CurrentlyBuildingJobs b)
        {
            if (a.RemainingTime < b.RemainingTime)
                return -1;
            else if (a.RemainingTime > b.RemainingTime)
                return 1;
            return 0;
        }
    }
}
