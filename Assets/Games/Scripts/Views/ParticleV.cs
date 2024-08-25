/*using UnityEngine;

public class ParticleV : MonoBehaviour
{
    public enum Particles
    {
        die
    }

    [SerializeField] private ParticleSystem dieParticle;

    public void PlayParticle(Particles particleType, Vector3 position)
    {
        switch (particleType)
        {
            case Particles.die:
                if (dieParticle != null)
                {
                    Instantiate(dieParticle, position, Quaternion.identity).Play();
                }
                break;
        }
    }
}
*/