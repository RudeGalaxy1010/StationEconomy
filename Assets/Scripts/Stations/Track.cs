using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TrackUI))]
public class Track : MonoBehaviour
{
    //Set in inspector
    [SerializeField] private Transform StartPoint, EndPoint;

    private Vehicle CurrentVehicle;
    public TrackUI TrackUI { get; private set; }
    public bool isBusy { get; private set; } = false;

    private void Start()
    {
        TrackUI = GetComponent<TrackUI>();
    }

    public void SetVehicle(Vehicle vehicle)
    {
        CurrentVehicle = Instantiate(vehicle, StartPoint.position, Quaternion.identity, transform);
        CurrentVehicle.SetTarget(EndPoint.position);
        isBusy = true;

        CurrentVehicle.OnDeparted += UnsetVehicle;
    }

    public void UnsetVehicle()
    {
        CurrentVehicle.OnDeparted -= UnsetVehicle;
        CurrentVehicle = null;
        isBusy = false;
    }
}
