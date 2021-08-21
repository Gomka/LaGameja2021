using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraspassarMuros : MonoBehaviour
{
    // Start is called before the first frame update
   void OnCollisionEnter2D(Collision2D collision)
   {
       if(collision.gameObject.tag == "MuroInvisible"){
           Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
       }
   }
}
