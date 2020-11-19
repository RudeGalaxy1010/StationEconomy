using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Schedule))]

// Base class for certain stations
public abstract class Station : MonoBehaviour
{
    // Set in inspector
    [Tooltip("Will be unlocked in order")]
    [SerializeField] protected List<Track> Tracks = new List<Track>();
    [SerializeField] private int unlockedTrackCount;

    public Schedule Schedule { get; private set; }

    private void Start()
    {
        Schedule = GetComponent<Schedule>();
        Schedule.OnReadyToArrive += CreateArrivalNotification;

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

    #region Arrival Notifications
    // Should be called by action in schedule
    public abstract void CreateArrivalNotification();

    public abstract void DestroyArrivalNotification();
    #endregion

    // Activate new track if possible and return result
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
