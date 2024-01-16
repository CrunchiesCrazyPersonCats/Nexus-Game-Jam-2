using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemiesPrefab;
    private Transform[] _spawner;
    private int _spawnerCount;
    private int _ennemyTypeCount;

    // Start is called before the first frame update
    void Start()
    {
        _spawnerCount = transform.childCount;
        _ennemyTypeCount = EnemiesPrefab.Length;
        _spawner = new Transform[_spawnerCount];
        Debug.Log(_spawner.Length);
        for (int i = 0; i < _spawnerCount; i++)
        {
            _spawner[i] = transform.GetChild(i);
        }
        StartSpawning(2f);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && IsInvoking("Spawn"))
        {
            StopSpawing();
        }else if (Input.GetKeyUp(KeyCode.R) && !IsInvoking("Spawn"))
        {
            StartSpawning(2f);
        }
    }
    public void StartSpawning(float interval)
    {
        InvokeRepeating("Spawn", 1f, interval);
    }

    public void StopSpawing()
    {
        CancelInvoke("Spawn");
    }

    public void Spawn()
    {
        Instantiate(EnemiesPrefab[Random.Range(0, _ennemyTypeCount)], _spawner[Random.Range(0, _spawnerCount)].position, Quaternion.identity);
    }
}
