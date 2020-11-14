using UnityEngine;

public class Train : Vehicle
{
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
}
