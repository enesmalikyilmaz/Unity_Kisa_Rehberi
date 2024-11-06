using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    public GameObject laserPrefab; 
    public Transform firePoint;    
    public float fireRate = 0.5f;  // Seri atışlar arası süre
    private float nextFire = 0f;   // Bir sonraki atış zamanı
    public float speed = 1f;
    public float lives = 3.0f;
    SpawnManager_sc spawnManager_sc;
        [SerializeField]

    bool isTripleShotActive = false;
    [SerializeField]
    GameObject tripleShotPrefab;

    void Start(){
        spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager_sc== null){
            Debug.Log("Spawn_Manager oyun nesnesi bulunamadı");
        }    }

    void Update()
    {
        CalculateMovement();

        // Space tuşuna basılı tutulduğunda ve bekleme süresi dolduğunda ateş et
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            if(!isTripleShotActive){
            FireLaser();

            }
            else{
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);

            }
            nextFire = Time.time + fireRate;

        }

    }
    void FireLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }

    void CalculateMovement(){

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(moveHorizontal,moveVertical,0) * speed * Time.deltaTime;

        if(transform.position.y<-3.9f){
             transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }
        if(transform.position.y>0.0f){
             transform.position = new Vector3(transform.position.x, 0, 0);
        }
        if(transform.position.x<-9.22f){
             transform.position = new Vector3(-9.22f, transform.position.y, 0);
        }
        if(transform.position.x>9.22f){
             transform.position = new Vector3(9.22f, transform.position.y, 0);
        }
    }

     public void Damage(){
        lives --;
        if(lives < 1)
        {
            if(spawnManager_sc != null){
            spawnManager_sc.OnPlayerDeath();
            } 
            Destroy(this.gameObject);
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Damage();
        }
    }
    */
    }
