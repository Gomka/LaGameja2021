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
        if(Vector2.Distance(transform.position, targetPlayer.position) < distance-1)
        {
            transform.position = Vector2.MoveTowards(transform.position,Vector2.Reflect(targetPlayer.position,new Vector2 (targetPlayer.position.y,targetPlayer.position.x)),speed* Time.deltaTime);
                
        }
        
    }
    
    void FixedUpdate(){
       
        

    
    }
}
