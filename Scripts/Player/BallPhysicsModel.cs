using System.Collections;
using UnityEngine;

public class BallPhysicsModel : MonoBehaviour
{
    Vector3 normalScale;
    internal Vector3 moveVector;
    BallPhysicsSettings settings = new BallPhysicsSettings();
    internal BallMovable ballMovable = new BallMovable();
    internal Material Material { get => material ??= GetComponent<MeshRenderer>().sharedMaterial; }
    Material material;

    private void OnEnable() =>  TouchProvider.handOverDirectionVector += ChangeMoveVector;
    private void OnDisable() => TouchProvider.handOverDirectionVector -= ChangeMoveVector;

    private void Awake() => normalScale = transform.localScale;
    private void FixedUpdate() => ChangePhysicsEveryFrame();

    void ChangePhysicsEveryFrame()
    {
        ballMovable.ReduceAcceleration();
        DoRotate();
        transform.localScale = Vector3.Lerp(transform.localScale, normalScale, 0.1f);
        Material.color = Color.Lerp(material.color, Color.white, settings.colorInterpolationModifier);
    }
    internal void ChangePhysicsParameters(Collision collision)
    {
        moveVector = Vector3.Reflect(moveVector, collision.GetContact(0).normal);
        ChangeRotation(moveVector);
        ChangeScaleOnHit(collision.GetContact(0).normal);
        ChangeColor();
    }
    void ChangeMoveVector(Vector3 directionalVector)
    {
        moveVector = Vector3.ProjectOnPlane(directionalVector, Vector3.up) + Vector3.up * .5f;
        ballMovable.Acceleration = Mathf.Clamp
            (directionalVector.magnitude, settings.minimalAcceleration, settings.maximalAcceleration);
        ChangeRotation(directionalVector);
    } 
    void ChangeRotation(Vector3 directionalVector) => transform.rotation =
        Quaternion.AngleAxis(Vector3.Angle(Vector3.forward, directionalVector), Vector3.up);

    void DoRotate() => 
        transform.Rotate(Vector3.right * AccelerationRatio() * 10);

    internal void ChangeScaleOnHit(Vector3 normal) => transform.localScale =
        transform.localScale - Vector3.ProjectOnPlane(normal, Vector3.up) *
        settings.scaleInterpolationModifier * AccelerationRatio();

    internal void ChangeColor() => material.color = new Color
        (AccelerationRatio(), 0, 0, 1);

    float AccelerationRatio() => ballMovable.Acceleration / settings.maximalAcceleration;
}