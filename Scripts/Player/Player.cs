using UnityEngine;

class Player : MonoBehaviour
{
    [SerializeField] MoneyUIController moneyController;
    [SerializeField] BallRicochetParticle ricochetParticle;

    ParticleFabric particleFabric = new ParticleFabric();
    BallPhysicsModel BallPhysics { get => ballPhysicsModel ??= GetComponentInChildren<BallPhysicsModel>(); }
    BallPhysicsModel ballPhysicsModel;

    void FixedUpdate() => Move();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) DoOnCollision(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(other.gameObject);
            moneyController.AddMoney(coin.currency);
        }
    }

    void DoOnCollision(Collision collision)
    {
        BallPhysics.ChangePhysicsParameters(collision);
        particleFabric.Create(ricochetParticle, transform.position,
            Quaternion.AngleAxis(Vector3.Angle(Vector3.forward, BallPhysics.moveVector), Vector3.up));
    }

    void Move() => BallPhysics.ballMovable.Move(gameObject.transform, BallPhysics.moveVector);

}
