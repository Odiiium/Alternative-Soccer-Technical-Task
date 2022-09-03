using System.Collections;
using UnityEngine;

public class BallPhysicsModel : MonoBehaviour
{
    internal Vector3 moveVector;
    BallPhysicsSettings settings = new BallPhysicsSettings();
    internal BallMovable ballMovable = new BallMovable();

    private void OnEnable() =>  TouchProvider.handOverDirectionVector += ChangeMoveVector;
    private void OnDisable() => TouchProvider.handOverDirectionVector -= ChangeMoveVector;
    private void FixedUpdate() => ChangePhysicsEveryFrame();

    void ChangeMoveVector(Vector3 directionalVector)
    {
        moveVector = directionalVector;
        ballMovable.Acceleration = Mathf.Clamp
            (directionalVector.magnitude, settings.minimalAcceleration, settings.maximalAcceleration);
    }

    void ChangePhysicsEveryFrame()
    {
        ballMovable.ReduceAcceleration();
        ChangeRotateVector();
    }

    void ChangeRotateVector() => transform.rotation *=
        Quaternion.Euler(new Vector3(moveVector.z, 0, moveVector.x) * ballMovable.Acceleration / settings.rotateModifier);

}