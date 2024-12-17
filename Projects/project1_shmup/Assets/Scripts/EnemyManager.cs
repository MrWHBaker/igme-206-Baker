using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ======== FIELDS ============================================================================
    public CollisionManager collisionManager;
    private float spawnTimer = 0f;
    private float spawnRequirement = 4f;
    public bool spawning = true;
    public int score = 0;

    private Vector3 spawnpoint = new Vector3(10, 0, 0);

    [SerializeField]
    private TextMesh scoreDisplay;

    // Enemy types
    [SerializeField]
    private GameObject fighterJet;
    [SerializeField]
    private GameObject spyPlane;

    // Projectile types
    [SerializeField]
    private GameObject bullet;
    

    // ======== METHODS ===========================================================================

    // Method to spawn an enemy
    private void NewEnemy()
    {
        // Choose a random enemy to spawn (Weighted for spy planes as 1 in 10
        int enemyType = Random.Range(0, 5);

        if (enemyType == 1)
        {
            GameObject newSpy = Instantiate(spyPlane, spawnpoint, Quaternion.identity);
            collisionManager.enemies.Add(newSpy);
            SpyPlane spyScript = newSpy.GetComponent<SpyPlane>();

            spyScript.enemyManager = gameObject.GetComponent<EnemyManager>();
        }
        else
        {
            GameObject newJet = Instantiate(fighterJet, spawnpoint, Quaternion.identity);
            collisionManager.enemies.Add(newJet);
            FighterJet jetScript = newJet.GetComponent<FighterJet>();

            jetScript.enemyManager = gameObject.GetComponent<EnemyManager>();
        }

    }

    // method to spawn a bullet
    public void NewBullet(bool isEnemy, Vector3 location, float verticalSpeed)
    {
        GameObject newBullet = Instantiate(bullet, location, Quaternion.identity);
        Projectile bulletScript = newBullet.GetComponent<Projectile>();

        bulletScript.enemyManager = gameObject.GetComponent<EnemyManager>();
        

        if (isEnemy)
        {
            collisionManager.projectilesEnemy.Add(newBullet);
            bulletScript.isEnemy = true;
        }
        else
        {
            bulletScript.verticalVelocityMod = verticalSpeed;

            //bullet.transform.rotation = Quaternion.Euler(0,0,180);
            collisionManager.projectilesPlayer.Add(newBullet);
            bulletScript.isEnemy = false;
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        collisionManager = GetComponent<CollisionManager>();
        scoreDisplay.text = ("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        // Display the score
        scoreDisplay.text = ("Score: " + score);

        // Spawn enemies over time
        if (spawnTimer >= spawnRequirement && spawning)
        {
            NewEnemy();
            spawnTimer = Random.Range(0,3);
        }
        spawnTimer += Time.deltaTime;
    }
}
