using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;

    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && ((Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed) || Mouse.current.leftButton.isPressed)){
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
        }
        
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
     

    }

    private void SpawnBlock() {
        score++;
        scoreText.text = score.ToString();
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
    }
}

