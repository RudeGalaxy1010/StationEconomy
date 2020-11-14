using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Schedule : MonoBehaviour
{
    //Using list instead of queue for inspector serialization
    [SerializeField] private List<VehicleType> VehicleQueue = new List<VehicleType>();
    [SerializeField] private VehicleType CurrentVehicle;
    private int vehicleIndex = 0;

    public UnityAction
        OnReadyToArrive,
        OnUnreadyToArrive;

    private void Start()
    {
        //Order by the arrival time
        VehicleQueue = VehicleQueue.
            OrderBy(t => t.GetArrivalTime().minArrivalTime.Hours).
            ThenBy(t => t.GetArrivalTime().minArrivalTime.Minutes).ToList();
    }

    private void Update()
    {
        //If time has come :)
        if (VehicleQueue[vehicleIndex].GetArrivalTime().minArrivalTime.Equals(WorldTimer.GlobalTime))
        {
            CurrentVehicle = VehicleQueue[vehicleIndex];
            //To control index range
            vehicleIndex = (vehicleIndex + 1) % VehicleQueue.Count;
            OnReadyToArrive?.Invoke();
        }

        //if waiting too long
        if (CurrentVehicle != null)
        {
            if (CurrentVehicle.GetArrivalTime().maxArrivalTime.Equals(WorldTimer.GlobalTime))
            {
                OnUnreadyToArrive?.Invoke();
                CurrentVehicle = null;
            }
        }
    }

    public VehicleType AcceptScheduledVehicle()
    {
        if (CurrentVehicle != null)
        {
            var vehicle = CurrentVehicle;
            CurrentVehicle = null;
            return vehicle;
        }

        throw new Exception("Vehicle is null!");
    }
}
