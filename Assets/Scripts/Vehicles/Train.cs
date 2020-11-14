using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : Vehicle
{
    private Vector3 startPoint;

    private void Start()
    {
        startPoint = transform.position;
    }

    private void Update()
    {
        if (transform.position != target)
        {
            //Move to the target
            Move(target);
        }
        else if (!isUnloaded)
        {
            //If stop at the track and need to be unloaded
            StartUnload();
        }
        else if (target != startPoint)
        {
            SetTarget(startPoint);
        }
        else
        {
            //If departed and reached start point
            Destroy(gameObject);
        }
    }

    public override void Move(Vector3 target)
    {
        var maxDistanceDelta = Time.deltaTime * GetSpeed();
        transform.position = Vector3.MoveTowards(transform.position, target, maxDistanceDelta);
    }

    public override void SetTarget(Vector3 target)
    {
        base.SetTarget(target);
    }
}
