using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Notification : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private Image icon;

    public UnityAction<Notification> OnClick;

    public void Set(string text = "", Sprite icon = null)
    {
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
            // Standard icon
        }
    }

    public void OnNotificationClicked()
    {
        OnClick?.Invoke(this);
    }

    public void DestroyNotification()
    {
        StationNotifications.Instance.OnNotificationClick(this);
    }
}
