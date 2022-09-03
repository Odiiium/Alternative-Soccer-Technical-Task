using UnityEngine;
class InputController
{
    Plane plane = new Plane(Vector3.up, Vector3.zero); 
    internal TouchProvider TouchProvider { get => touchProvider ??= new TouchProvider(); }
    TouchProvider touchProvider;
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
        TouchProvider.StartTouchPosition(aim, GetWorldPointPosition);
        TouchProvider.GetContiniousPosition(GetWorldPointPosition);
        TouchProvider.GetEndTouchPosition(aim, GetWorldPointPosition);
    }
}