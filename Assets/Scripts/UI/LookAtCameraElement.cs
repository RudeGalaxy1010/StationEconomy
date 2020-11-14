using UnityEngine;

public class LookAtCameraElement : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.position - Camera.main.transform.position);
    }
}
