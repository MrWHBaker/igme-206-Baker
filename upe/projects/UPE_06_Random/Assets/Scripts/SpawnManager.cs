using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Build;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    // ======== FIELDS ============================================================================
    // List of animal sprites
    [SerializeField]
    private List<Sprite> animalSprites;
    // Creature prefab
    [SerializeField]
    private GameObject creature;

    // List of currently extant creatures
    [SerializeField]
    private List<GameObject> activeCreatures;

    // Array of colors for randomization
    Color[] colors = new Color[]
    {
    Color.black, Color.blue, Color.red, Color.green, Color.cyan,
    Color.white, Color.gray, Color.yellow, Color.magenta
    };
   

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Spawns randomized creatures when button is pressed
    public void Spawn()
    {
        CleanUp();

        // Set # of creatures spawned for now
        int creatureCount = Random.Range(20, 40);

        // Calls SpawnCreature helper method
        // Keeps track of the GameObjects created so we can destroy them later
        for (int i = 0; i < creatureCount; i++)
        {
            activeCreatures.Add(SpawnCreature());
            Vector3 position = new Vector3(Gaussian(0, 2), Gaussian(0, 2), 0);
            activeCreatures[i].transform.position = position;
        }

    }

    // Method to set up a creature to be spawned
    public GameObject SpawnCreature()
    {
        GameObject newCreature = Instantiate(creature);
        SpriteRenderer creatureSprite = newCreature.GetComponent<SpriteRenderer>();

        // Set the creature's sprite and color
        creatureSprite.sprite = ChooseRandomCreature();
        creatureSprite.color = colors[Random.Range(0, colors.Length)];

        return newCreature;
    }

    // Method to choose which creature is spawned
    public Sprite ChooseRandomCreature()
    {
        // non-uniform
        int rng = Random.Range(0, 100);

        // 25% Elephant
        if (rng < 25)
        {
            return animalSprites[0];
        }
        // 20% Turtle
        else if (rng < 45)
        {
            return animalSprites[1];
        }
        // 15% Snail
        else if (rng < 60)
        {
            return animalSprites[2];
        }
        // 10% Octopus
        else if (rng < 70)
        {
            return animalSprites[3];
        }
        // 30% Kangaroo
        else
        {
            return animalSprites[4];
        }

    }

    // Method to clean up space of all creatures
    void CleanUp()
    {
        while (activeCreatures.Count != 0)
        {
            Destroy(activeCreatures[0]);
            activeCreatures.RemoveAt(0);
        }
    }

    // Gaussian function provided within project instruction document
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
