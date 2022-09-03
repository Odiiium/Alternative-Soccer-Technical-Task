using UnityEngine;

public class BallMovable : IMovable
{
    float speedModifier = .1f;
    internal float Acceleration { get => acceleration; set => acceleration = value; }
    float acceleration;

    public void Move(Transform transform, Vector3 moveVector) =>
        transform.position += moveVector * Acceleration * Time.deltaTime * speedModifier;

    internal void ReduceAcceleration() => Acceleration =
        Acceleration > 0 ? Acceleration -= Time.deltaTime : 0;

    internal void SetAcceleration(float value) => Acceleration = value;
}
