using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject[] prefabs;
    public int poolSize = 15;
    public float spawnRate = 1500f;

    private GameObject[] pool;
    private int currentPool = 0;

    private Vector2 objectPoolPosition = new Vector2(-15, -25);

    void Start()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            var prefab = prefabs[Random.Range(0, prefabs.Length)];
            pool[i] = (GameObject)Instantiate(prefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        if (Game.instance.gameOver == false && Game.instance.absoluteX >= spawnRate)
        {
            var poolObject = pool[currentPool].GetComponent<PoolObject>();

            float spawnYPosition = Random.Range(poolObject.minYPosition, poolObject.maxYPosition);

            int lastPool = currentPool - 1;

            if (currentPool == 0)
            {
                lastPool = 15;
            }

            float spawnXPosition = Random.Range(poolObject.minXPosition, poolObject.maxXPosition);

            //float lastSpawnXPosition = pool[lastPool].transform.position.x;
            float lastSpawnXPosition = 0f;

            pool[currentPool].transform.position = new Vector2(lastSpawnXPosition + spawnXPosition, spawnYPosition);

            Game.instance.absoluteX = 0;

            currentPool++;

            if (currentPool >= poolSize)
            {
                currentPool = 0;
            }
        }
    }
}
