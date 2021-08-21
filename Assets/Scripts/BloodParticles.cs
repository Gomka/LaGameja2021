using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem blood;
    [SerializeField] private AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void BloodParticlesEvent()
    {
        blood.Play();
        source.PlayOneShot(clip);
    }
}
