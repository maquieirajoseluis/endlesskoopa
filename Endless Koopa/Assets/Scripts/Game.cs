using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameObject gameOverText;

    private GameObject introImage;

    public Text scoreText;

    public bool gameOver = false;

    public float scrollSpeed = 7f;

    public AudioClip coinSound;

    private int score = 0;

    private bool doingIntro = true;

    private float introDelay = 2f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        InitGame();
    }

    void Update()
    {
        if (gameOver && Input.GetButtonUp("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Scored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        Audio.instance.PlaySingle(coinSound);
        scoreText.text = score.ToString("D4");
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    void InitGame()
    {
        doingIntro = true;

        introImage = GameObject.Find("Intro");

        introImage.SetActive(true);

        Invoke("LoadStaticIntro", introDelay);

    }

    void LoadStaticIntro()
    {
        introImage.SetActive(false);

        doingIntro = false;
    }
}
