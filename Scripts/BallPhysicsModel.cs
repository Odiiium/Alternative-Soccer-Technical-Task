using System.Collections;
using UnityEngine;

public class BallPhysicsModel : MonoBehaviour
{
    internal Vector3 moveVector;
    BallPhysicsSettings settings = new BallPhysicsSettings();
    internal BallMovable BallMovable { get => ballMovable ??= new BallMovable(); }
    BallMovable ballMovable;

    private void OnEnable() => InputController.handOverDirectionVector += ChangeMoveVector;
    private void OnDisable() => InputController.handOverDirectionVector -= ChangeMoveVector;
    private void Update() => ChangePhysicsEveryFrame();

    void ChangeMoveVector(Vector3 directionalVector)
    {
        moveVector = directionalVector;
        ballMovable.Acceleration = Mathf.Clamp
            (directionalVector.magnitude, settings.minimalAcceleration, settings.maximalAcceleration);
    }

    void ChangePhysicsEveryFrame()
    {
        BallMovable.ReduceAcceleration();
        ChangeRotateVector();
    }

    void ChangeRotateVector() => transform.rotation *=
        Quaternion.Euler(moveVector * ballMovable.Acceleration / settings.rotateModifier);

}