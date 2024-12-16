using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.UI;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ======== FIELDS ============================================================================
    public CollisionManager collisionManager;
    private float spawnTimer = 0f;
    private float spawnRequirement = 5f;

    // Enemy types
    [SerializeField]
    private GameObject fighterJet;

    // Projectile types
    [SerializeField]
    private GameObject bullet;

    // ======== METHODS ===========================================================================

    // Method to spawn an enemy
    private void NewEnemy()
    {
        GameObject newJet = Instantiate(fighterJet);
        collisionManager.enemies.Add(newJet);
        FighterJet jetScript = newJet.GetComponent<FighterJet>();

        jetScript.enemyManager = gameObject.GetComponent<EnemyManager>();

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
        NewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn enemies over time
        if (spawnTimer >= spawnRequirement)
        {
            NewEnemy();
            spawnTimer = Random.Range(0,3);
        }
        spawnTimer += Time.deltaTime;
    }
}
