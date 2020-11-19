using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class StationNotifications : MonoBehaviour
{
    public static StationNotifications Instance;

    [SerializeField] private Notification notificationPrefab;
    private List<Notification> Notifications = new List<Notification>();
    private VerticalLayoutGroup layoutGroup;

    private void Start()
    {
        Instance = this;
        layoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    public Notification CreateNotification(string message)
    {
        var note = Instantiate(notificationPrefab, layoutGroup.transform.position, Quaternion.identity, layoutGroup.transform);
        var height = (int)(note.GetComponent<RectTransform>().rect.height / 2);
        layoutGroup.padding.top -= height;
        layoutGroup.padding.bottom -= height;

        note.Set(message);

        Notifications.Add(note);
        return note;
    }

    public void DestroyNotification(Notification note)
    {
        var height = (int)(note.GetComponent<RectTransform>().rect.height / 2);
        layoutGroup.padding.top += height;
        layoutGroup.padding.bottom += height;

        Notifications.Remove(note);
        Destroy(note.gameObject);
    }

    public void DestroyFirstNotifiaction()
    {
        if (Notifications.Count > 0)
        {
            var note = Notifications[0];
            DestroyNotification(note);
        }
    }

    public void OnNotificationClick(Notification note)
    {
        DestroyNotification(note);
    }
}
