using UnityEngine;
class ParticleFabric : IFabric<GameParticle>
{
    public GameParticle Create(GameParticle particle, Vector3 position, Quaternion rotation) => GameObject.
        Instantiate(particle, position, rotation, null);

    public GameParticle Create(GameParticle particle, Transform transform) => GameObject.
        Instantiate(particle, transform.position, Quaternion.identity, null);
    
}

