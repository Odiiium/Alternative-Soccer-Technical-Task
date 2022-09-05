using UnityEngine;

class PlayerBall : MonoBehaviour
{
    [SerializeField] MoneyUIController moneyController;
    BallPhysicsModel BallPhysics { get => ballPhysicsModel ??= GetComponent<BallPhysicsModel>(); }
    BallPhysicsModel ballPhysicsModel;

    void FixedUpdate() => Move();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            BallPhysics.moveVector = Vector3.Reflect(BallPhysics.moveVector, collision.GetContact(0).normal);
            //BallPhysics.ChangeScaleOnHit(collision.GetContact(0).normal);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(other.gameObject);
            moneyController.AddMoney(coin.currency);
        }
    }

    void Move() => BallPhysics.ballMovable.Move(gameObject.transform, BallPhysics.moveVector);

}