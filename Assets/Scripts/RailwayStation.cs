using System.Collections.Generic;
using UnityEngine;

public class RailwayStation : MonoBehaviour
{
    public List<Track> Tracks = new List<Track>();
    /// <summary>
    /// TODO: delete this
    /// </summary>

    public Train TestTrain;

    private void Start()
    {
        if (TestTrain != null)
        {
            SetTrain(0, TestTrain);
        }
    }

    public void SetTrain(int trackIndex, Train trainToArrive)
    {
        try
        {
            Tracks[trackIndex].SetTrain(trainToArrive);
        }
        catch
        {
            Debug.LogError($"Failed to spawn train \"{trainToArrive}\" at {trackIndex + 1} track");
        }
        ///TODO: Stop play mode
    }
}
