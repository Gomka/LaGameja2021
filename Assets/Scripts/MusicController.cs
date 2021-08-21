using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject go in objs) if (this.gameObject != go)
            {
                if(go.GetComponent<AudioSource>().clip != this.gameObject.GetComponent<AudioSource>().clip)
                {
                    Destroy(go);
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }

        DontDestroyOnLoad(this.gameObject);
    }
}
