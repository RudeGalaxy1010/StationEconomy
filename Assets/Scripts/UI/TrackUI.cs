using UnityEngine;
using UnityEngine.UI;

public class TrackUI : MonoBehaviour
{
    public Button AvailableButton;

    private void Start()
    {
        AvailableButton.gameObject.SetActive(false);
    }

    public void ShowAvailableButton(bool isActive = true)
    {
        AvailableButton.gameObject.SetActive(isActive);
    }
}
