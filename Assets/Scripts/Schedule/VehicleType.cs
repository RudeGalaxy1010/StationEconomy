using System;
using UnityEngine;

// Base class for schedule vehicle
[Serializable]
public class VehicleType
{
    [SerializeField] private GlobalTime minArrivalTime, maxArrivalTime;
    // TODO: should make generic for such things?
    public bool isPassThrough;
    public bool isForwardSpawn;

    [SerializeField] private Vehicle prefab;

    #region GetInfo Methods

    public Vehicle GetPrefab()
    {
        if (prefab != null)
        {
            return prefab;
        }

        throw new Exception("Prefab is null!");
    }

    public (GlobalTime minArrivalTime, GlobalTime maxArrivalTime) GetArrivalTime()
    {
        return (minArrivalTime, maxArrivalTime);
    }

    #endregion
}