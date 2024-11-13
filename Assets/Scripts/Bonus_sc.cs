using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(transform.position.y<-5.8f){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag ==  "Player")
        {
                    Player_sc player_sc = other.transform.GetComponent<Player_sc>();
                    if(player_sc != null){
                        player_sc.ActiveTripleShot();
                    }

            Destroy(this.gameObject);
        }
    }
    
}
