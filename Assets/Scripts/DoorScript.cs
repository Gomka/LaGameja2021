using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    private LevelLoader levelLoader;
    [SerializeField] string targetLevel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private bool isOpen = false;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public override void Interact()
    {
        if(inside && !isOpen)
        {
            isOpen = true;
            audioSource.PlayOneShot(audioClip);
            levelLoader.LoadLevel(targetLevel);
        }
    }

    public override void Exit()
    {

    }
}
