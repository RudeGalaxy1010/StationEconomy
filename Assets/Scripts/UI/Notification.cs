using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private Image icon;
    private StationNotifications notifications;

    public void Set(StationNotifications notifications, string text = "", Sprite icon = null)
    {
        this.notifications = notifications;
        if (text != "")
        {
            textField.text = text;
        }
        else
        {
            textField.text = "Standard text";
        }

        if (icon != null)
        {
            this.icon.sprite = icon;
        }
        else
        {
            //Standard icon
        }
    }

    public void OnNotificationClicked()
    {
        notifications.RemoveNotification(this);
    }
}
