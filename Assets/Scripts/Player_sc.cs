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
    public float speedMultiplier = 2f;

    public float lives = 3.0f;
    SpawnManager_sc spawnManager_sc;

    bool isTripleShotActive = false;
    bool isSpeedBonusActive = false;
    bool isShieldBonusActive = false;

    [SerializeField]
    GameObject tripleShotPrefab;
    [SerializeField]
    GameObject shieldVisualizer ;

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

            Instantiate(laserPrefab, transform.position, Quaternion.identity);

            }
            else{
                Vector3 tripleShotPosition = transform.position + new Vector3(-4.5f, 0, 0);
                Instantiate(tripleShotPrefab, tripleShotPosition, Quaternion.identity);

            }
            nextFire = Time.time + fireRate;

        }

    }
    
    /*void FireLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }*/

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

     public void Damage()
     {
        if(isShieldBonusActive == true)
        {
            isShieldBonusActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        lives --;
        if(lives < 1)
        {
            if(spawnManager_sc != null){
            spawnManager_sc.OnPlayerDeath();
            } 
            Destroy(this.gameObject);
        }
    }

    public void ActiveTripleShot(){

        isTripleShotActive = true;

        StartCoroutine(TripleShotBonusDisableRoutine());

    }

    public void ActivateSpeedBonus(){

        isSpeedBonusActive = true;

        speed *= speedMultiplier;

        StartCoroutine(SpeedBonusDisableRoutine());
    }
    public void ActivateShieldBonus(){

        isShieldBonusActive = true;

        shieldVisualizer.SetActive(true);

        StartCoroutine(ShieldBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        isTripleShotActive = false;

    }    

    IEnumerator SpeedBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed /= speedMultiplier;

        isSpeedBonusActive = false;

    }
    IEnumerator ShieldBonusDisableRoutine()
    {
        yield return new WaitForSeconds(10.0f);

        shieldVisualizer.SetActive(false);
        isShieldBonusActive = false;

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
