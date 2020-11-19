public class RailwayStation : Station
{
    private VehicleType acceptedVehicle;

    // Call by button and show buttons on available tracks to choose
    public void OnArrivalAccept(Notification callingNote)
    {
        ResetTracksUI();

        var atLeastOneFree = false;

        foreach (var track in Tracks)
        {
            var isFree = track.ShowAvailability();
            if (!atLeastOneFree && isFree)
            {
                atLeastOneFree = true;
            }
        }

        if (atLeastOneFree)
        {
            // Destroy notification
            callingNote.DestroyNotification();

            // Unsubscribe from note click action
            callingNote.OnClick -= OnArrivalAccept;

            // Get vehicle from schedule
            acceptedVehicle = Schedule.AcceptScheduledVehicle();
        }
    }

    // Auxiliary function
    private void ResetTracksUI()
    {
        foreach (var track in Tracks)
        {
            track.ResetUI();
        }
    }
    
    // Call by button when choose track to arrive and tells track to spawn vehicle
    public void OnChooseTrack(Track track)
    {
        track.SetVehicle(acceptedVehicle);
        ResetTracksUI();
    }

    #region Arrival Notification
    public override void CreateArrivalNotification()
    {
        var note = StationNotifications.Instance.CreateNotification("Train arrival");
        note.OnClick += OnArrivalAccept;
    }

    public override void DestroyArrivalNotification()
    {
        StationNotifications.Instance.DestroyFirstNotifiaction();
    }
    #endregion
}
