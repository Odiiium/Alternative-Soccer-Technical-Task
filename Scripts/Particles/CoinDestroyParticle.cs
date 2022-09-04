using UnityEngine;

class CoinDestroyParticle : GameParticle
{
    public override float Time => 2.5f;

    internal override void Start()
    {
        ParticleSystem[] particlesArray = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particlesArray.Length; i++) 
            particlesArray[i].Emit((int)particlesArray[i].emission.rateOverTime.constant);
        base.Start();

    }
}

