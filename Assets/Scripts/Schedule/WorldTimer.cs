using System;
using System.Collections;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    public static WorldTimer Instance;
    public static GlobalTime GlobalTime;
    public static float TimeScale;

    //Set in inspector
    [SerializeField] private GlobalTime StartTime = new GlobalTime(00, 30);

    private void Awake()
    {
        Instance = this;

        TimeScale = 1;
        GlobalTime = StartTime;

        StartCoroutine(IncreaseTime());
    }

    private IEnumerator IncreaseTime()
    {
        //+1 min. for 2 real sec.
        yield return new WaitForSeconds(TimeScale * 2);
        GlobalTime.AddMinutes(1);
        StartCoroutine(IncreaseTime());
    }

    public string GetCurrentTime()
    {
        return GlobalTime.ToString();
    }

    public void AddHours(int value)
    {
        GlobalTime.AddHours(value);
    }

    public void AddMinutes(int value)
    {
        GlobalTime.AddMinutes(value);
    }
}

[Serializable]
public class GlobalTime
{
    [SerializeField] private int hours;
    [SerializeField] private int minutes;

    public int Hours 
    { 
        get { return hours; } 
        set { 
            if (value >= 0 && value <= 23)
            {
                hours = value;
            }
            else
            {
                hours = value % 24;
            }
            } 
    }
    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value >= 0 && value <= 59)
            {
                minutes = value;
            }
            else
            {
                minutes = (value % 60);
                Hours += (value / 60);
            }
        }
    }

    public GlobalTime() { }

    public GlobalTime(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public void AddHours(int value)
    {
        Hours += value;
    }

    public void AddMinutes(int value)
    {
        Minutes += value;
    }

    public override string ToString()
    {
        return string.Format("Time: {0:D2}:{1:D2}", Hours, Minutes);
    }

    public override bool Equals(object obj)
    {
        var globalTimeObj = (GlobalTime)obj;

        if (globalTimeObj != null)
        {
            if (globalTimeObj.Hours == Hours && globalTimeObj.Minutes == Minutes)
            {
                return true;
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
