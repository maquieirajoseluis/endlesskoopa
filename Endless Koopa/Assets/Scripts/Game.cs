using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameObject gameOverText;

    public GameObject introImage;

    public Text scoreText;

    public bool gameOver = false;
    public bool objectCollision = false;

    public float scrollSpeed = 7f;

    public AudioClip coinSound;

    public AudioClip fireSound;

    public AudioClip gameOverSound;

    public GameObject[] grounds;

    public bool intro = true;

    private int score = 0;

    private float introDelay = 1f;

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
        Audio.instance.PlaySingle(fireSound);
        scoreText.text = score.ToString("D4");
    }

    public void GameOver()
    {
        Audio.instance.PlaySingle(gameOverSound);
        gameOverText.SetActive(true);
        gameOver = true;
    }


    public void ObjectCollision()
    {
        gameOver = false;
        objectCollision = true;
    }

    void InitGame()
    {
        intro = true;


        for (int i = 0; i < grounds.Length; i++)
        {
            var ground = (GameObject)Instantiate(grounds[i], new Vector3(i * 20.48f, 0), Quaternion.identity);
            ground.transform.position = new Vector2(i * 20.48f, 0);
        }

        introImage.SetActive(true);

        Invoke("LoadStaticIntro", introDelay);
    }

    void LoadStaticIntro()
    {
        introImage.SetActive(false);

        intro = false;
    }
}
