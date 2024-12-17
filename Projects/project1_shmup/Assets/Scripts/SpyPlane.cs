using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyPlane : Enemy
{
    float shotDelay = 0f;
    float shotRequirement = 0.25f;
    private UFO ufo;

    protected override void Behavior()
    {
        if (ufo.health > 0)
        {
            Attack();
            FollowPlayerY(5);
        }
        else
        {
            Seek(new Vector3(-10,0,0),5);
        }

    }

    protected override void Attack()
    {
        if (shotDelay > shotRequirement)
        {
            enemyManager.NewBullet(true, position, velocity.y * 100);
            shotDelay = 0;
        }
        else
        {
            shotDelay += Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        points = 300;
        position.x = Random.Range(4f,6f);
        target = enemyManager.collisionManager.player;

        // Random starting y position
        position.y = 6;

        health = 5;
        mass = 1;
        maxSpeed = Random.Range(3f,5f);

        ufo = target.GetComponent<UFO>();

        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

        StayInBounds(5);
        base.Update();
    }
}
