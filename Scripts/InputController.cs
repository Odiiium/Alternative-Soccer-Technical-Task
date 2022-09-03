using UnityEngine;
using UnityEngine.Events;
class InputController
{
    internal Vector3 startTouchPosition, endTouchPosition;
    internal static UnityAction<Vector3> handOverDirectionVector;
    Plane plane = new Plane(Vector3.up, Vector3.zero); 

    internal void StartTouchPosition(Aim aim)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                aim.gameObject.SetActive(true);
                startTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
            }
        }
    }
    internal void GetContiniousPosition()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                endTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
            }
        }
    }

    internal void GetEndTouchPosition(Aim aim)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                aim.gameObject.SetActive(false);
                endTouchPosition = GetWorldPointPosition(Input.GetTouch(0).position);
                handOverDirectionVector?.Invoke(MoveVector());
            }
        }
    }

    Vector3 GetWorldPointPosition(Vector3 vector)
    {
        Vector3 hitPoint = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(vector);
        if (plane.Raycast(ray, out float enter))
            hitPoint = ray.GetPoint(enter);
        return hitPoint;
    }
    internal void DoAimingCycle(Aim aim)
    {
        StartTouchPosition(aim);
        GetContiniousPosition();
        GetEndTouchPosition(aim);
    }
    internal Vector3 MoveVector() => endTouchPosition - startTouchPosition;


}