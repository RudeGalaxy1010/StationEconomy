public class RailwayStation : Station
{
    //Call by button and show buttons on available tracks to choose
    public void OnArrivalAccept()
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
            StationUI.HideArrivalButton();
        }
    }

    //Auxiliary function
    private void ResetTracksUI()
    {
        foreach (var track in Tracks)
        {
            track.ResetUI();
        }
    }
    
    //Call by button when choose track to arrive and tells track to spawn vehicle
    public void OnChooseTrack(Track track)
    {
        var vehicle = Schedule.AcceptScheduledVehicle();

        track.SetVehicle(vehicle);
        ResetTracksUI();
    }
}
