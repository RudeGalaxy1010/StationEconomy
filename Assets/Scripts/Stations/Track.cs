using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrackUI))]
public class Track : MonoBehaviour
{
    // Set in inspector
    [Tooltip("Should be assigned like: Start, Stop, End")] public List<RoutePoint> Route = new List<RoutePoint>(3);

    private Vehicle CurrentVehicle;
    private RoutePoint spawnPoint, destinationPoint;
    private bool isPassThrough;

    public bool isBusy { get; private set; } = false;
    public TrackUI TrackUI { get; private set; }

    private void Awake()
    {
        TrackUI = GetComponent<TrackUI>();
    }

    public void SetVehicle(VehicleType vehicle)
    {
        isPassThrough = vehicle.isPassThrough;
        spawnPoint = vehicle.isForwardSpawn ? Route[0] : Route[2];
        // Set to stopPoint
        destinationPoint = Route[Route.Count/2 + 1];

        CurrentVehicle = Instantiate(vehicle.GetPrefab(), spawnPoint.GetPosition(), Quaternion.identity, transform);
        CurrentVehicle.SetTarget(destinationPoint.GetPosition());
        isBusy = true;

        CurrentVehicle.OnUnloaded += PrepareForDeparture;
        CurrentVehicle.OnDeparted += UnsetVehicle;
    }

    public void PrepareForDeparture()
    {
        CurrentVehicle.OnUnloaded -= PrepareForDeparture;

        if (isPassThrough)
        {
            if (spawnPoint == Route[0])
            {
                destinationPoint = destinationPoint.GetNextPoint();
            }
            else
            {
                destinationPoint = destinationPoint.GetPreviousPoint();
            }
        }
        else
        {
            if (spawnPoint == Route[0])
            {
                destinationPoint = destinationPoint.GetPreviousPoint();
            }
            else
            {
                destinationPoint = destinationPoint.GetNextPoint();
            }
        }

        CurrentVehicle.SetTarget(destinationPoint.GetPosition());
    }

    public void UnsetVehicle()
    {
        CurrentVehicle.OnDeparted -= UnsetVehicle;
        CurrentVehicle = null;
        isBusy = false;
    }

    public bool ShowAvailability()
    {
        if (!isBusy)
        {
            TrackUI.ShowAvailableButton();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetUI()
    {
        if (gameObject.activeSelf)
        {
            TrackUI.ShowAvailableButton(false);
        }
    }
}
