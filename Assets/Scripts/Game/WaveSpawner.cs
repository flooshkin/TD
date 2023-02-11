using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private int maxSumEnemy = 30;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Wave waves;
    [SerializeField] private float coefficientGold = 1.1f;
    [SerializeField] private int timeBetweenWaves = 5;
    [SerializeField] private float spawnInterval = 10;
    [SerializeField] private int LifeIncrease = 10;
    
    private GameManagerBehavior gameManager;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    private int randomEnemy;

    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
    
    public void Update()
    {
        if (gameManager.Health != 0)
        {
            
            int randomAmountEnemy = Random.Range(10, maxSumEnemy);
            float timeInterval = Time.time - lastSpawnTime;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < randomAmountEnemy)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = Instantiate(enemy[randomEnemy]);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }
            if (enemiesSpawned == randomAmountEnemy)
            {
                randomEnemy = Random.Range(0, enemy.Length);
                // gameManager.HealthEnemy += LifeIncrease;
                gameManager.Wave++;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * coefficientGold);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }
    
    

}
