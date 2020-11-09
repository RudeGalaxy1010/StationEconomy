using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform SpawnPoint, EndPoint;
    private Train train;

    public void SetTrain(Train trainToArrive)
    {
        var arrivingTrain = Instantiate(trainToArrive.gameObject, SpawnPoint.transform.position, Quaternion.identity, SpawnPoint.transform);
        train = arrivingTrain.GetComponent<Train>();
        train.SetTarget(EndPoint.position);
    }
}
