using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();
    //public abstract void OverLine(bool as);
    

    private void entering(Collider2D coll)
    {
        /* if(collision.CompareTag("Player"))
            OverLine(true) */

            
    }
    private void exiting(Collider2D coll)
    {
        /* if(collision.CompareTag("Player"))
            OverLine(false) */
    }
}
