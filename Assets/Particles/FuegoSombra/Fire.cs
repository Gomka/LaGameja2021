using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform copia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void FixedUpdate()
    {
        transform.position = copia.position + new Vector3 (0f,0f,0.02f);
    }
}
