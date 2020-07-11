using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.scripts {
    [System.Serializable]
    public class Movement : MonoBehaviour
    {
        //Basic variables to keep track of this object's instance variables. The object to keep track of the 
        //movement of the object bounded to this script will be constructed before the first frame update.  
        private const float MovementSpeed = 8f;
        private const float JumpForce = 15f;

        //A vector to define the horizontal movement in terms of Forces such as Frictional forces 
        // or normal force. 
        private Vector3 _horizontalMovement; 
        
        //Allows for the sprite in question to be put under control of the unity physics engine. This allows 
        //for the sprite to be affected by gravity and can be controlled from scripts using force; hence, these scripts. 
        [SerializeField] private Rigidbody2D rigid;
        
        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            rigid = transform.GetComponent<Rigidbody2D>(); 
        }

        // Update is called once per frame
        private void Update()
        { 
            var scale = MovementSpeed * Time.deltaTime;
            _horizontalMovement.x *= scale;
            _horizontalMovement.y *= scale;
            _horizontalMovement.z *= scale;
            transform.position += _horizontalMovement; 
            if (Input.GetKeyDown(KeyCode.W)) //&& Math.Abs(rigid.velocity.y) < 0.00)
            {
                //rigid.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
                rigid.velocity = Vector2.up * JumpForce;
            }
        }
    }
}
