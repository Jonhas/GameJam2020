using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chug_damage : MonoBehaviour
{
    public int attackDamage = 10; 
    public float attackRange = 1f; 
    public Vector3 damageOffset; 
    public LayerMask damageMask; 

    public void Attack(){
        Vector3 position = transform.position; 
        position+= transform.right*damageOffset.x;
        position+=transform.up * damageOffset.y; 

        Collider2D colInfo = Physics2D.OverlapCircle(position, attackRange, damageMask); 
        if(colInfo!=null){
            colInfo.GetComponent<health>().takeDamage(attackDamage); 
        }
    }

    void onDrawGizmoSelected(){
        Vector3 position = transform.position; 
        position+= transform.right*damageOffset.x;
        position+=transform.up * damageOffset.y; 
        Gizmos.DrawWireSphere(position,attackRange); 
    }
}
