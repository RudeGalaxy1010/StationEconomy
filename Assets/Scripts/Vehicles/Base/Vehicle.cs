using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// All vehicle classes should inherit from this class
public class Vehicle : MonoBehaviour
{
    // Set in inspector
    [SerializeField] private new string name = "Vehicle";
    [SerializeField] private float speed = 1f;
    [SerializeField] private float unloadTime = 5f;
    
    protected Vector3 target;

    public bool isUnloaded { get; private set; } = false;
    public UnityAction OnUnloaded;
    public UnityAction OnDeparted;

    public void StartUnload()
    {
        StartCoroutine(Unload(unloadTime));
    }

    public virtual void Move(Vector3 target) { }

    public virtual void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    private void OnDestroy()
    {
        Debug.Log("Departed");
        OnDeparted?.Invoke();
    }

    private IEnumerator Unload(float time)
    {
        yield return new WaitForSeconds(time);
        isUnloaded = true;
        OnUnloaded?.Invoke();
    }

    #region GetInfo Methods

    public float GetSpeed()
    {
        return speed;
    }

    public float GetUnloadTime()
    {
        return unloadTime;
    }

    public string GetName()
    {
        return name;
    }

    #endregion
}
