using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    private LevelLoader levelLoader;
    [SerializeField] string targetLevel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public override void Interact()
    {
        if(inside)
        {
            audioSource.PlayOneShot(audioClip);
            levelLoader.LoadLevel(targetLevel);
        }
    }

    public override void Exit()
    {

    }
}
