using UnityEngine;
class AimCaster : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] InputController inputController;

    internal void CastLine()
    {
        aim.AimLine.SetPosition(0, inputController.startTouchPosition);
        aim.AimLine.SetPosition(1, inputController.endTouchPosition);
    }
}