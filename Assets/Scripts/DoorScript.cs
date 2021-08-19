using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    private LevelLoader levelLoader;
    [SerializeField] string targetLevel;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public override void Interact()
    {
        levelLoader.LoadLevel(targetLevel);
    }

    public override void Exit()
    {

    }
}
