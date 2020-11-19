using UnityEngine;

public class StationShop : MonoBehaviour
{
    [SerializeField] private Station Station;

    public void OnBuyButtonClicked()
    {
        // Check money, etc.
        Station.TryAddTrack();
    }
}
