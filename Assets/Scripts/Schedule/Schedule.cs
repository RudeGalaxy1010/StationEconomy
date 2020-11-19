using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Schedule : MonoBehaviour
{
    // Using list instead of queue for inspector serialization
    [SerializeField] private List<VehicleType> VehicleQueue = new List<VehicleType>();
    [SerializeField] private List<VehicleType> CurrentVehicles = new List<VehicleType>();
    private int vehicleIndex = 0;

    public UnityAction
        OnReadyToArrive,
        OnUnreadyToArrive;

    private void Start()
    {
        // Order by the arrival time
        VehicleQueue = VehicleQueue.
            OrderBy(t => t.GetArrivalTime().minArrivalTime.Hours).
            ThenBy(t => t.GetArrivalTime().minArrivalTime.Minutes).ToList();
    }

    private void Update()
    {
        // If time has come :)
        if (VehicleQueue[vehicleIndex].GetArrivalTime().minArrivalTime.Equals(WorldTimer.GlobalTime))
        {
            CurrentVehicles.Add(VehicleQueue[vehicleIndex]);
            //To control index range
            vehicleIndex = (vehicleIndex + 1) % VehicleQueue.Count;
            OnReadyToArrive?.Invoke();
        }

        if (CurrentVehicles.Count > 0)
        {
            // If waiting too long
            if (CurrentVehicles[0].GetArrivalTime().maxArrivalTime.Equals(WorldTimer.GlobalTime))
            {
                OnUnreadyToArrive?.Invoke();
                CurrentVehicles.RemoveAt(0);
            }
        }
    }

    public VehicleType AcceptScheduledVehicle()
    {
        try
        {
            var vehicle = CurrentVehicles[0];
            CurrentVehicles.RemoveAt(0);
            return vehicle;
        }
        catch (Exception)
        {
            Debug.LogError("Vehicle arrival queue is null!");
        }

        return null;
    }
}
