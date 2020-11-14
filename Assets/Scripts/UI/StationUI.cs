using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Station))]
public class StationUI : MonoBehaviour
{
    public Button ArrivalButton;
    private Station Station;

    private void Start()
    {
        Station = GetComponent<Station>();

        ArrivalButton.gameObject.SetActive(false);

        Station.Schedule.OnReadyToArrive += ShowArrivalButton;
        Station.Schedule.OnUnreadyToArrive += HideArrivalButton;
    }

    public void ShowArrivalButton()
    {
        ArrivalButton.gameObject.SetActive(true);
    }

    public void HideArrivalButton()
    {
        ArrivalButton.gameObject.SetActive(false);
    }
}
