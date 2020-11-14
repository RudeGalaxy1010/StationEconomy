using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Schedule))]
[RequireComponent(typeof(StationUI))]

//Base class for certain stations
public abstract class Station : MonoBehaviour
{
    //Set in inspector
    [Tooltip("Will be unlocked in order")]
    [SerializeField] protected List<Track> Tracks = new List<Track>();
    [SerializeField] private int unlockedTrackCount;

    public Schedule Schedule { get; private set; }
    public StationUI StationUI { get; private set; }

    private void Awake()
    {
        Schedule = GetComponent<Schedule>();
        StationUI = GetComponent<StationUI>();

        for (int i = 0; i < Tracks.Count; i++)
        {
            if (i >= unlockedTrackCount)
            {
                Tracks[i].gameObject.SetActive(false);
            }
            else
            {
                Tracks[i].gameObject.SetActive(true);
            }
        }
    }

    //Activate new track if possible and return result
    public bool TryAddTrack() 
    {
        if (unlockedTrackCount < Tracks.Count)
        {
            Tracks[unlockedTrackCount].gameObject.SetActive(true);
            unlockedTrackCount++;
            return true;
        }

        return false;
    }
}
