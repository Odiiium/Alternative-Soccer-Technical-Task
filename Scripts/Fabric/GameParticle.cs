using UnityEngine;
using System.Collections;
internal abstract class GameParticle : MonoBehaviour
{
    public virtual float Time { get => 1;}

    internal virtual void Start() => StartCoroutine(DestroyParticleSystem(Time));

    private IEnumerator DestroyParticleSystem(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}