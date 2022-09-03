using UnityEngine;
class AimCaster : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] PlayerBall player;
    float aimLength = 8;
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
        aim.AimLine.SetPosition(0, new Vector3(playerPosition.x, 0, playerPosition.z));
        if (inputController.MoveVector().magnitude < aimLength)
            aim.AimLine.SetPosition(1, InputController.MoveVector() + playerPosition);
    }

}