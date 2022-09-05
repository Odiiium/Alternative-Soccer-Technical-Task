using UnityEngine;

public class BallMovable : IMovable
{
    float speedInterpolationModifier = .22f;
    internal float Acceleration { get => acceleration; set => acceleration = value; }
    float acceleration;

    public void Move(Transform transform, Vector3 directionVector) => transform.position =
        Vector3.ProjectOnPlane(MoveVector(transform, directionVector), Vector3.up) + Vector3.up * .5f;

    private Vector3 UpdatedPosition(Transform transform, Vector3 moveVector) =>
        transform.position + moveVector * Acceleration * Time.deltaTime;

    internal void ReduceAcceleration() => Acceleration =
        Acceleration > 0 ? Acceleration -= Time.deltaTime : 0;

    internal void SetAcceleration(float value) => Acceleration = value;

    Vector3 MoveVector(Transform transform, Vector3 vectorToMove) => Vector3.Lerp
        (transform.position, UpdatedPosition(transform, vectorToMove), speedInterpolationModifier);
}
