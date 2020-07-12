using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class health : MonoBehaviour
{
    private int _health = 1; 

    public GameObject deathEffect; 

    public void takeDamage(int damage){
        _health-=damage; 
        StartCoroutine(damageAnimation()); 
        if (_health <=0) Die(); 
    }

    void Die(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }   

    IEnumerator damageAnimation()
    {
        SpriteRenderer[] src = GetComponentsInChildren<SpriteRenderer>(); 
        for(int i = 0; i < 3; i++){
            foreach(SpriteRenderer sr in src){
                Color c = sr.color; 
                c.a = 0; 
                sr.color = c; 
            }

            yield return new WaitForSeconds(.1f); 
            foreach(SpriteRenderer sr in src){
                Color c = sr.color; 
                c.a = 1; 
                sr.color = c; 
            }
            yield return new WaitForSeconds(.1f); 
        }
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
