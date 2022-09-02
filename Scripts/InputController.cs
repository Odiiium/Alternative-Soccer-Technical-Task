using UnityEngine;

class InputController
{
    internal Vector3 startTouchPosition, endTouchPosition;

    internal void StartTouchPosition()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;
    }

    internal void GetEndTouchPosition()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
            endTouchPosition = Input.GetTouch(0).position;
    }

    internal void GetContiniousPosition()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
            endTouchPosition = Input.GetTouch(0).position;
    }

    Vector3 MoveVector()
    {
        Vector3 positionToMove = endTouchPosition - startTouchPosition;
        return new Vector3(positionToMove.x, 0, positionToMove.z);
    }

}