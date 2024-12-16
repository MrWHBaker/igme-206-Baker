using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public abstract class CollidableObject : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    public EnemyManager enemyManager;

    // Holds information about an object's hitbox
    [SerializeField]
    public float maxX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;

    public float MaxX { get { return maxX; } }
    public float MaxY { get { return maxY; } }
    public float MinX { get { return minX; } }
    public float MinY { get { return minY; } }

    // Holds the 'team' this entity is a part of (Player or Enemy)
    public bool isEnemy;

    // Tracks whether the object has been hit by an enemy
    public bool isHit;

    // ======== METHODS ===========================================================================

    // Start is called before the first frame update
    protected virtual void Start()
    {
        isHit = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isHit)
        { spriteRenderer.color = Color.red; }
        else
        { spriteRenderer.color = Color.white; }
        isHit = false;
    }
}
