using UnityEngine;

class PlayerBall : MonoBehaviour
{
    BallPhysicsModel BallPhysics { get => ballPhysicsModel ??= GetComponent<BallPhysicsModel>(); }
    BallPhysicsModel ballPhysicsModel;

    void FixedUpdate() => Move();
    private void OnCollisionEnter(Collision collision) => BallPhysics.moveVector =
    Vector3.Reflect(BallPhysics.moveVector, collision.GetContact(0).normal);
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
            Destroy(other.gameObject);
    }

    void Move() => BallPhysics.ballMovable.Move(gameObject.transform, BallPhysics.moveVector);


}