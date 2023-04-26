using UnityEngine;

public class StartParticles : MonoBehaviour
{
    private ParticleSystem particles;
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Play();
        
    }
}
