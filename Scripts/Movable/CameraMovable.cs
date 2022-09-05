using UnityEngine;

class CameraMovable : IMovable
{
    float interpolateSpeedModifier = .2f;
    Vector3 cameraOffset = new Vector3(0, 9.36f, -7.09f);

    public void Move(Transform transform, Vector3 positionToMove) => transform.position =
        Vector3.Lerp(transform.position, positionToMove + cameraOffset, interpolateSpeedModifier);
}