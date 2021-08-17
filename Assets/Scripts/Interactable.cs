using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputHandler input;
    protected bool inside=false;
    void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();
    //public abstract void OverLine(bool as);
    
     private void OnEnable()
    {
        input.PlayerInteractionEvent += Interact;
    }

    private void OnDisable()
    {

        input.PlayerInteractionEvent -= Interact;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
         if(col.CompareTag("Player"))
            inside = true;
           /* OverLine(true) */
        
            
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exiting");
         if(col.CompareTag("Player"))
            /*OverLine(false) */
        inside = false;
    }
}
