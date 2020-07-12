using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chug_flip : MonoBehaviour
{
    private Transform player; 
    public bool isFlipped = false; 

    private void Awake(){
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform; 
    }

    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale; 
        flipped.z *= -1f; 
        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped; 
            initFlip(false); 
        } 
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped; 
            initFlip(true); 
        }    
    }

    public void flipping(){ LookAtPlayer();}
    private void initFlip(bool value){
        transform.Rotate(0f,180f,0f); 
        isFlipped = value; 
    }
}
