using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] footsteps;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
    }
}
