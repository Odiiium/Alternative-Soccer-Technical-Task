using UnityEngine;

public class BallMovable
{
    internal void DoMove(Transform transform, Vector3 movePosition)
    {
        transform.Translate(movePosition);
    }

}
