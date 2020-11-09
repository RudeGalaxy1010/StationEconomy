using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSpeed = 5f;
    private Quaternion newRotation;

    private void Start()
    {
        newRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(0, 90, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * RotationSpeed);
    }
}
