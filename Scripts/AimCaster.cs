using UnityEngine;
class AimCaster
{
    Aim aim;

    internal AimCaster(Aim _aim) => aim = _aim;

    internal void CastLine(Vector3 startPosition, Vector3 endPosition)
    {
        aim.AimLine.SetPosition(0, startPosition);
        aim.AimLine.SetPosition(0, endPosition);
    }

}