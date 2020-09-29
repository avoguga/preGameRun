using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    struct SpawnTime
    {
        public float instantiateTime;
        public float interval;
        public float variation;
    }

    public Sprite[] cactusSprites;

    public GameObject cactusPrefabRef;

    SpawnTime cactus;

    public bool stopSpawn = false;


    public float speed = 4;

    void Start()
    {

        cactus.instantiateTime = 0;
        cactus.interval = 2;
        cactus.variation = 0.5f;


    }

    void Update()
    {

        // spawn cactus
        if (Time.time > cactus.instantiateTime && !stopSpawn)
        {
            GameObject obj = Instantiate(cactusPrefabRef, new Vector3(5, -0.9f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<Cactus>().speed = speed;
            cactus.instantiateTime = Time.time + Random.Range(cactus.interval - cactus.variation, cactus.interval + cactus.variation);
        }

    }
}
