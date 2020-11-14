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
    [SerializeField] private List<VehicleType> CurrentVehicle = new List<VehicleType>();
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
            CurrentVehicle.Add(VehicleQueue[vehicleIndex]);
            //To control index range
            vehicleIndex = (vehicleIndex + 1) % VehicleQueue.Count;
            OnReadyToArrive?.Invoke();
        }

        //if waiting too long
        if (CurrentVehicle.Count > 0)
        {
            if (CurrentVehicle[0].GetArrivalTime().maxArrivalTime.Equals(WorldTimer.GlobalTime))
            {
                OnUnreadyToArrive?.Invoke();
                CurrentVehicle.RemoveAt(0);
            }
        }
    }

    public VehicleType AcceptScheduledVehicle()
    {
        if (CurrentVehicle.Count > 0)
        {
            var vehicle = CurrentVehicle[0];
            CurrentVehicle.RemoveAt(0);
            return vehicle;
        }

        throw new Exception("Vehicle arrival queue is null!");
    }
}
