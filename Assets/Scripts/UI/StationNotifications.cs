using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class StationNotifications : MonoBehaviour
{
    [SerializeField] private Notification notificationPrefab;
    private VerticalLayoutGroup layoutGroup;

    private void Start()
    {
        layoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    public void AddNotification(string message)
    {
        var note = Instantiate(notificationPrefab, layoutGroup.transform.position, Quaternion.identity, layoutGroup.transform);
        var height = (int)(note.GetComponent<RectTransform>().rect.height / 2);
        layoutGroup.padding.top -= height;
        layoutGroup.padding.bottom -= height;
    }

    public void RemoveNotification(Notification note)
    {
        var height = (int)(note.GetComponent<RectTransform>().rect.height / 2);
        layoutGroup.padding.top += height;
        layoutGroup.padding.bottom += height;
        Destroy(note.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AddNotification("Test");
        }
    }

    public void Clicked()
    {
        Debug.Log("Clicked");
    }
}
