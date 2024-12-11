using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.0f;

    Player_sc player_sc ;


    // Start is called before the first frame update
    void Start()
    {
        player_sc = GameObject.FindObjectOfType<Player_sc>();
        if (player_sc == null)
        {
            Debug.LogError("Player scripti bulunamadı!");
        }
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
   void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Player"))
    {
        Player_sc player = other.GetComponent<Player_sc>();
        if (player != null)
        {
            player.Damage();
        }

        Destroy(this.gameObject);
    }
    else if (other.CompareTag("Laser"))
    {
        Destroy(other.gameObject);

        if (player_sc != null)
        {
            player_sc.UpdateScore(10);
        }

        Destroy(this.gameObject);
    }
    }

   
}
