using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            playerRB.velocity =Vector2.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColorChanger"))
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       

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
}
