using UnityEngine;

class PlayerBall : MonoBehaviour
{
    BallPhysicsModel BallPhysics { get => ballPhysicsModel ??= GetComponent<BallPhysicsModel>(); }
    BallPhysicsModel ballPhysicsModel;

    void FixedUpdate() => Move();
    private void OnCollisionEnter(Collision collision) => BallPhysics.moveVector =
    Vector3.Reflect(BallPhysics.moveVector, collision.GetContact(0).normal);
    void Move() => BallPhysics.BallMovable.DoMove(gameObject.transform, BallPhysics.moveVector);


}