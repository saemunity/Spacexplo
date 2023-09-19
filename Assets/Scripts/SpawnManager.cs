using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _objects;
    public float spawnRate;
    public float timeBetweenWave = 3.0f;
    bool canSpawn = true;
    int spawnCount;

    // int waveCount;

    GameObject _spawnedObject;
    int randomX,
        randomY,
        _randomX,
        _randomY;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true)
        {
            StartCoroutine(Spawn());
        }
    }

    private void StartSpawn()
    {
        Vector2 position1 = new Vector2(37, 21);
        Vector2 position2 = new Vector2(-37, -21);
        _spawnedObject = Instantiate(_objects[0], position1, Quaternion.identity) as GameObject;
        _spawnedObject = Instantiate(_objects[1], position2, Quaternion.identity) as GameObject;
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        WaitForSeconds wave = new WaitForSeconds(timeBetweenWave);

        canSpawn = false;

        for (int i = 0; i < spawnCount; i++)
        {
            int randomObjectId = Random.Range(0, _objects.Length);
            Vector2 position = GetRandomCoordinates();
            _spawnedObject =
                Instantiate(_objects[randomObjectId], position, Quaternion.identity) as GameObject;

            yield return wait;
        }

        spawnCount += 5;

        if (ScoreManager.instance._score < 19)
        {
            spawnRate = 1.5f;
        }
        else if (ScoreManager.instance._score > 19 && ScoreManager.instance._score < 69)
        {
            spawnRate = 1.0f;
        }
        else
        {
            spawnRate = 0.75f;
        }

        yield return wave;
        canSpawn = true;
    }

    Vector2 GetRandomCoordinates()
    {
        randomX = Random.Range(-60, 60);
        randomY = Random.Range(-40, 40);

        if (randomX > -37 && randomX < 37)
        {
            _randomX = Random.Range(-37, 37);
            randomY = Random.Range(25, 40);
            _randomY = Random.Range(-40, -25);
        }
        else if (randomY > -25 && randomY < 25)
        {
            randomX = Random.Range(38, 60);
            _randomX = Random.Range(-60, -38);
            _randomY = Random.Range(-25, 25);
        }

        int[] arrayPointX = { randomX, _randomX };
        int[] arrayPointY = { randomY, _randomY };

        int randomPointX = Random.Range(0, arrayPointX.Length);
        int randomPointY = Random.Range(0, arrayPointY.Length);

        Vector2 coordinates = new Vector2(arrayPointX[randomPointX], arrayPointY[randomPointY]);
        return coordinates;
    }
}
