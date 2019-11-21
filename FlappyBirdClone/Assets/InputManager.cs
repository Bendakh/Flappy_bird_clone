using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;

    private const string POINT_TAG = "Point";
    private const string OBSTACLE_TAG = "Obstacle";

    private int score;

    private Rigidbody2D rb2d;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    [Range(100,300)]
    private float jumpPower;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, jumpPower));
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(POINT_TAG))
            score++;
        else if(collision.CompareTag(OBSTACLE_TAG))
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverPanel.SendMessage("SetScore");
        }

    }
}
