using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchizoToilet : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public void SpawnPlayer()
    {
        player.SetActive(true);
    }

    public void DespawnPlayer()
    {
        player.SetActive(false);
    }

}
