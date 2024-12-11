using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager_sc : MonoBehaviour
{
    private GameManager_sc gameManager_sc;

    [SerializeField]
    private TextMeshProUGUI scoreTMP;

    [SerializeField]
    private TextMeshProUGUI gameOverTMP;

    [SerializeField]
    private TextMeshProUGUI restartTMP;

    [SerializeField]
    private Image livesImg;

    [SerializeField]
    private Sprite[] livesSprites;

    // Start is called before the first frame update
    void Start()
    {
        // GameManager'ı bulma
        gameManager_sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
        if (gameManager_sc == null)
        {
            Debug.LogError("GameManager bulunamadı!");
        }

        // Başlangıç değerleri
        scoreTMP.text = "Score: " + 0;
        livesImg.sprite = livesSprites[3];
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }
    void update ()
    {
        
    }

    public void UpdateScoreTMP(int score)
    {
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLivesImg(int currentLives)
    {
        if (currentLives < livesSprites.Length && currentLives >= 0)
        {
            livesImg.sprite = livesSprites[currentLives];
        }
        else
        {
            Debug.LogError("Lives değeri geçersiz!");
        }

        if (currentLives == 0)
        {
            //gameManager?.GameOver(); // GameManager null değilse GameOver çağır
            gameOverTMP.gameObject.SetActive(true);
            restartTMP.gameObject.SetActive(true);

            StartCoroutine(GameOverFlickerRoutine());
        }
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverTMP.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
