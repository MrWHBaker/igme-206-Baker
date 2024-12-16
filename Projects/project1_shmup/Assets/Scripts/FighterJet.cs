using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJet : Enemy
{
    // ======== FIELDS ============================================================================
    float shotDelay = 0f;
    float shotRequirement = 1f;
    int bulletChain = 0;
    int chainMax = 3;

    // ======== METHODS ===========================================================================

    protected override void Attack()
    {
        if (bulletChain >= chainMax)
        {
            shotDelay = 0f;
            bulletChain = 0;
            shotReady = false;
        }
        else
        {
            shotDelay = shotRequirement - 0.125f;
            bulletChain += 1;
            enemyManager.NewBullet(true, position, velocity.y * 100);
        }
    }

    protected override void Behavior()
    {
        float distanceY = Mathf.Abs(target.transform.position.y - position.y);
        if (shotDelay > shotRequirement && distanceY < 1)
        {
            shotReady = true;
        }

        if (shotDelay > shotRequirement && shotReady) { Attack(); }

        shotDelay += Time.deltaTime;

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        // slightly randomized vertical and horizontal trajectory
        velocity.x = Random.Range(-0.002f,-0.0015f);
        velocity.y = Random.Range(-0.0025f, 0.0025f);

        health = 5;
        mass = 1;
        maxSpeed = 1;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Behavior();
        Bounce();
        base.Update();
    }

}
