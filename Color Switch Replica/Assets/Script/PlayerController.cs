﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float speed = 5.0f;
    public string currentColor;
    private SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorMagenta;

    private AudioSource playerAudio;
    public AudioClip sound;
    public AudioClip collectSound;
    public AudioClip jumpSound;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public ParticleSystem explosionParicle;

    public bool isPlayerAlive =true;

    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
        playerAudio = GetComponent<AudioSource>();
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) && isPlayerAlive)
        {
            playerRB.velocity =Vector2.up * speed;
            playerAudio.PlayOneShot(jumpSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColorChanger"))
        {
            playerAudio.PlayOneShot(collectSound);
            SetRandomColor();
            Destroy(collision.gameObject);
            Instantiate(explosionParicle, transform.position, Quaternion.identity);
            UpdateScore(10);
            return;
        }
        if (collision.tag != currentColor)
        {
            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true);
            isPlayerAlive = false;
            restartButton.gameObject.SetActive(true);
            
        }
        if(collision.tag == currentColor)
        {
            playerAudio.PlayOneShot(sound);
        }
       

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;

        }
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}
