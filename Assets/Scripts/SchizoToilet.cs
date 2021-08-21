using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchizoToilet : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    private void Start()
    {
        source.PlayOneShot(clip);
    }

    public void SpawnPlayer()
    {
        player.SetActive(true);
    }

    public void DespawnPlayer()
    {
        player.SetActive(false);
    }
}
