using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y <-5.4f){
            float randomX = Random.Range(-9.4f,+9.4f);

            transform.position = new Vector3(randomX,7.5f,transform.position.z);
        }
    }
    void OnTriggerEnter2D(Collider2D other){

    if(other.tag == "Player"){

        Player_sc player_sc = other.transform.GetComponent<Player_sc>();

        if(player_sc != null){
            player_sc.Damage();
        }

        Destroy(this.gameObject);
        }
     else if(other.tag == "Laser"){
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
    }

   
}
