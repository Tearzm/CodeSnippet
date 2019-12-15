using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pops;
using PResources;

public class PopsManager
{
    //Not yet implemented
    //private Settlement mySettlement;

    private Spawner popSpawner;

    //Not yet implemented
    //private UpgradeTree upgradeTree;

    public List<Person> MyPops;

    public PopsManager(DefaultJobs jobs)
    {
        MyPops = new List<Person>();
        popSpawner = new Spawner(jobs);
    }

    public PopsManager(DefaultJobs jobs, ResourceActor actor)
    {
        MyPops = new List<Person>();
        popSpawner = new Spawner(jobs, actor);
    }


    public PopsManager(DefaultJobs jobs, ResourceActor actor, int MaxPop)
    {
        MyPops = new List<Person>();
        popSpawner = new Spawner(jobs, actor, MaxPop);
    }

    /// <summary>
    /// Spawn a new pop of the given job type
    /// </summary>
    /// <param name="_job"></param>
    public void BuildANewPop(JobTypesList _job)
    {
        popSpawner.AddPop(_job);
    }

    /// <summary>
    /// Used when passing a turn and returns any built pops
    /// </summary>
    public void PassTurn()
    { 
        List<Person> temp = new List<Person>();
        temp = popSpawner.PassTurn();
        //DEBUG HERE FOR GARBAGE COLLECTION
        List<Person> newList = new List<Person>(MyPops.Count + temp.Count);
        newList.AddRange(MyPops);
        newList.AddRange(temp);
        MyPops = newList;
    }

    /// <summary>
    /// Add more jobs to spawn
    /// </summary>
    /// <param name="j"></param>
    public void AddJobs(DefaultJobs j)
    {
        popSpawner.AddJobs(j);
    }

    /// <summary>
    /// Gets a full list of available jobs to build
    /// </summary>
    /// <returns></returns>
    public DefaultJobs availableJobs()
    {
        return popSpawner.availabeJobs();
    }

    /// <summary>
    /// Get current population
    /// </summary>
    /// <returns></returns>
    public int GetPopulation()
    {
        return popSpawner.getPopulation();
    }

    /// <summary>
    /// Get current maximum population
    /// </summary>
    /// <returns></returns>
    public int GetMaxPopulation()
    {
        return popSpawner.getMaxPopulation();
    }

    /// <summary>
    /// for debugging now
    /// </summary>
    public void ShowAllPops()
    {
        for (int i = 0; i < MyPops.Count; i++)
        {
            Debug.Log(MyPops[i].GetJobType().ToString());
        }
    }

}
