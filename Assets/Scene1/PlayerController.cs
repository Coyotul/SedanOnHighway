using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float carSpeed;
    private float maxPos;

    private Vector3 position;
    private static float timer = 0f;
    private float score = 0f;
    private float highScore = 0f;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
        _audioSource.loop = true;
        // Găsește toate obiectele cu tag-ul "car"
        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

        // Șterge fiecare obiect găsit
        foreach (GameObject car in cars)
        {
            Destroy(car);
        }
        restartButton.SetActive(false);
        position = transform.position;
        // Inițializează scorul și high score-ul salvate anterior (dacă există)
        score = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "High Score: " + highScore.ToString("0");
        // Ascunde panoul de Game Over la începutul jocului
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        score = timer;
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        // Control prin touch screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchPos = Camera.main.ScreenToWorldPoint(touch.position).x;
                position.x = Mathf.Clamp(touchPos, -2.19f, 2.19f);
            }
        }
        // Control prin tilt
        else
        {
            float tiltPos = Input.acceleration.x;
            position.x += tiltPos * carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -2.19f, 2.19f);
        }

        transform.position = position;
        
        // Actualizează textul pentru scor
        scoreText.text = score.ToString("0");
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource.clip = _audioClips[1];
        _audioSource.Play();
        _audioSource.loop = false;
        timer = 0f;

        Time.timeScale = 0f;
        Debug.Log("Game Over"); // Exemplu: Afiseaza "Game Over" in consola

        // Verifică dacă scorul curent este mai mare decât high score-ul
        if (score > highScore)
        {
            // Actualizează high score-ul
            highScore = score;
            // Actualizează textul pentru high score
            highScoreText.text = "High Score: " + highScore.ToString("0");
            // Salvează high score-ul în PlayerPrefs
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Afiseaza panoul de Game Over si butonul de a juca din nou
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);
    }
    

    public void RestartGame()
    {
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
        _audioSource.loop = true;
        // Găsește toate obiectele cu tag-ul "car"
        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

        // Șterge fiecare obiect găsit
        foreach (GameObject car in cars)
        {
            Destroy(car);
        }
        // Reseteaza timpul, scorul și poziția jucătorului
        timer = 0f;
        score = 0f;
        position = transform.position;

        // Ascunde panoul de Game Over și repornește jocul
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public static float GetTimer()
    {
        return timer;
    }
    
    
}