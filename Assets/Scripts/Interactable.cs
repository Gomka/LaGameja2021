using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{

    private InputHandler input;
    protected bool inside=false;

    

    void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact();
    public void OverLine(bool near){
        Debug.Log("Fuera");
        if(near){
            Debug.Log("Dentro");
             gameObject.GetComponent<Renderer>().sharedMaterial.SetInt("_Colliding", 1);
             Debug.Log("Cambio");
        }
        else{
            gameObject.GetComponent<Renderer>().sharedMaterial.SetInt("_Colliding", 0);
        }
    }
    
    private void OnEnable()
    {
        input = FindObjectOfType<InputHandler>();
        input.PlayerInteractionEvent += Interact;
    }

    private void OnDisable()
    {
        input.PlayerInteractionEvent -= Interact;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            inside = true;
            OverLine(true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            inside = false;
            OverLine(false);
    }
}
