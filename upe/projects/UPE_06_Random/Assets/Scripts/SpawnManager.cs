using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    protected SpawnManager() { }

    public List<Sprite> creatureSprites;
    public GameObject creaturePrefab;

    private List<GameObject> spawnedCreatures = new List<GameObject>();

    public float meanX = 0f;
    public float stdDevX = 2f;
    public float meanY = 0f;
    public float stdDevY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Spawn()
    {
        int randoNumCreatures = Random.Range(5, 15); 
        for (int i = 0; i < randoNumCreatures; i++ )
        {
            SpawnCreature();
        }
    }

    private void SpawnCreature()
    {
        Sprite chosenSprite = ChooseRandoCreature();

        GameObject newCreature = Instantiate(creaturePrefab, new Vector2(Gaussian(meanX, stdDevX), Gaussian(meanY, stdDevY),Quaternion.identity);
        newCreature.GetComponent<SpriteRenderer>().sprite = chosenSprite;


    }

    private Sprite ChooseRandoCreature()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
