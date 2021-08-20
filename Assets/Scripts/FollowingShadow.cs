using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingShadow : MonoBehaviour
{
    public Transform targetPlayer;
    
    private Animator ar;
    public float speed =5f;

    public float distance =3f;
    
    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
         if(Vector2.Distance(transform.position, targetPlayer.position)> distance)
        {
            transform.position = Vector2.MoveTowards(transform.position,targetPlayer.position,speed* Time.deltaTime);
                
        }
        else if(Vector2.Distance(transform.position, targetPlayer.position) < distance-0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position,Vector2.Reflect(targetPlayer.position,new Vector2 (targetPlayer.position.y,targetPlayer.position.x)),speed* Time.deltaTime);
                
        }
        else{
        ar.SetFloat("Speed", 0f);
       }
        
    }
    
    void FixedUpdate(){
        Vector3 movement=transform.position-targetPlayer.position;
       if(movement.x >0 && movement.x>movement.y){
        ar.SetFloat("Horizontal",-1f);
        ar.SetFloat("Vertical", 0f);
        ar.SetFloat("Speed", movement.sqrMagnitude);
       }
       else if(movement.x <0 && movement.x<movement.y){
        ar.SetFloat("Horizontal",1f);
        ar.SetFloat("Vertical", 0f);
        ar.SetFloat("Speed", movement.sqrMagnitude);   
       }
       else if(movement.y >0 && movement.y>movement.x){
        ar.SetFloat("Horizontal",0f);
        ar.SetFloat("Vertical", -1f);
        ar.SetFloat("Speed", movement.sqrMagnitude); 
       }
       else if(movement.y <0 && movement.y<movement.x){
        ar.SetFloat("Horizontal",0f);
        ar.SetFloat("Vertical", 1f);
        ar.SetFloat("Speed", movement.sqrMagnitude); 
       }
    }
}
