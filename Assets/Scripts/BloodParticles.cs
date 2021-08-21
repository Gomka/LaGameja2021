using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticles : MonoBehaviour
{
    private ParticleSystem blood;
    [SerializeField] private AudioClip clip;
    private AudioSource source;

    void Start()
    {
        blood = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    public void BloodParticlesEvent()
    {
        blood.Play();
        source.PlayOneShot(clip);
    }
}
