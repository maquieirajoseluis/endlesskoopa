using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 5;
    public float spawnRate = 3f;
    public float min = -2f;
    public float max = 2f;

    private GameObject[] pool;
    private int currentPool = 0;

    private Vector2 objectPoolPosition = new Vector2(-15, -25);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0f;

        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = (GameObject)Instantiate(prefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (Game.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(min, max);

            pool[currentPool].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentPool++;

            if (currentPool >= poolSize)
            {
                currentPool = 0;
            }
        }
    }
}
