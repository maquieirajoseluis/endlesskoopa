using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameObject gameOverText;

    public Text scoreText;

    public bool gameOver = false;

    public float scrollSpeed = 7f;

    public AudioClip coinSound;

    private int score = 0;

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
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
}
