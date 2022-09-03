using UnityEngine;
using UnityEngine.Events;

class TouchProvider
{
    internal static UnityAction<Vector3> handOverDirectionVector;
    internal Vector3 startTouchPosition, endTouchPosition;

    internal void StartTouchPosition(Aim aim, Func<Vector3, Vector3> GetWorldPointPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            aim.gameObject.SetActive(true);
            startTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
        }
    }

    internal void GetContiniousPosition(Func<Vector3, Vector3> GetWorldPointPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            endTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
    }

    internal void GetEndTouchPosition(Aim aim, Func<Vector3, Vector3> GetWorldPointPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            aim.gameObject.SetActive(false);
            endTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
            handOverDirectionVector?.Invoke(MoveVector());
        }
    }
    internal Vector3 MoveVector() => endTouchPosition - startTouchPosition;

    internal delegate K Func<in T, out K>(T type);

}