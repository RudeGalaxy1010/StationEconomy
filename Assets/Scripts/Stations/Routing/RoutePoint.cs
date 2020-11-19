using UnityEngine;

public class RoutePoint : MonoBehaviour
{
    [SerializeField] private RoutePoint NextPoint;
    [SerializeField] private RoutePoint PreviousPoint;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public RoutePoint GetNextPoint()
    {
        return NextPoint;
    }

    public RoutePoint GetPreviousPoint()
    {
        return PreviousPoint;
    }
}
