public class RailwayStation : Station
{
    //Call by button and show buttons on available tracks to choose
    public void OnArrivalAccept()
    {
        ResetTracksUI();

        var atLeastOneFree = false;

        foreach (var track in Tracks)
        {
            if (!track.isBusy)
            {
                track.TrackUI.ShowAvailableButton(true);
                atLeastOneFree = true;
            }
        }

        if (atLeastOneFree)
        {
            StationUI.HideArrivalButton();
        }
    }

    //Auxiliary function
    private void ResetTracksUI()
    {
        foreach (var track in Tracks)
        {
            track.TrackUI.ShowAvailableButton(false);
        }
    }
    
    //Call by button when choose track to arrive and tells track to spawn vehicle
    public void OnChooseTrack(Track track)
    {
        if (!track.isBusy)
        {
            var vehicle = Schedule.AcceptScheduledVehicle();
            var prefab = vehicle.GetPrefab();

            track.SetVehicle(prefab);
            ResetTracksUI();
        }
    }
}
