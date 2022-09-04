using UnityEngine;
class Coin : MonoBehaviour
{
    internal int currency = 50;

    [SerializeField] CoinDestroyParticle coinDestroyParticle;
    ParticleFabric particleFabric = new ParticleFabric();

    private void Update() => transform.Rotate(Vector3.up, 3);

    private void OnDestroy() => SpawnParticle();
    void SpawnParticle() => particleFabric.Create(coinDestroyParticle, gameObject.transform);

}