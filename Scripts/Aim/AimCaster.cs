using UnityEngine;
class AimCaster : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] Player player;
    InputController InputController { get => inputController ??= new InputController(); }
    InputController inputController;

    private void Update()
    {
        InputController.DoAimingCycle(aim);
        CastLine();
    }
    internal void CastLine()
    {
        Vector3 playerPosition = player.transform.position;
        aim.AimLine.SetPosition(0, Vector3.ProjectOnPlane(playerPosition, Vector3.up) + Vector3.up * .5f);
        aim.AimLine.SetPosition(1, InputController.TouchProvider.MoveVector() + playerPosition);
    }

}