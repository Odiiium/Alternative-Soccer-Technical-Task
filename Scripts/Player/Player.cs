using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField] MoneyUIController moneyController;
    BallPhysicsModel BallPhysics { get => ballPhysicsModel ??= GetComponentInChildren<BallPhysicsModel>(); }
    BallPhysicsModel ballPhysicsModel;

    void FixedUpdate() => Move();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) BallPhysics.ChangePhysicsParameters(collision);
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