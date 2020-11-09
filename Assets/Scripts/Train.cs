using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Train : MonoBehaviour
{
    public float Speed = 2f;
    public float UnloadTime = 10f;

    private Vector3 StartPoint;
    private Vector3 Target;
    /// <summary>
    /// TODO: Slow breaking
    /// </summary>
    private float CurrentSpeed;
    private bool isDeparture = false;

    public UnityAction OnEndUnload;

    private void Start()
    {
        CurrentSpeed = Speed;
        StartPoint = transform.position;

        OnEndUnload += Depart;
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    private void Update()
    {
        if (Target != null)
        {
            if (transform.position != Target)
            {
                //Moving
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * CurrentSpeed);
            }
            else
            {
                //Departure and destroy when at start position
                if (isDeparture)
                {
                    Destroy(gameObject);
                }
                else
                {
                    //Stop and unload
                    StartCoroutine(Unload(UnloadTime));
                }
            }
        }
        else
        {
            Debug.LogError("No target!");
        }
    }

    private IEnumerator Unload(float time)
    {
        yield return new WaitForSeconds(time);
        OnEndUnload?.Invoke();
    }

    private void Depart()
    {
        isDeparture = true;
        SetTarget(StartPoint);
    }
}
