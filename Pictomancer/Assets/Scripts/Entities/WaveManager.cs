using Pictomancer.Enemies;
using Pictomancer.Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemiesPrefab;
    private Transform[] _spawner;
    public List<EnemieController> EnnemiesList {  get; private set; }

    private int _spawnerCount;
    private int _ennemyTypeCount;
    [SerializeField] private int _interval;
    [SerializeField] private int _spawnStart;

    // Start is called before the first frame update
    void Start()
    {
        EnnemiesList = new List<EnemieController>();
        _spawnerCount = transform.childCount;
        _ennemyTypeCount = EnemiesPrefab.Length;
        _spawner = new Transform[_spawnerCount];
        for (int i = 0; i < _spawnerCount; i++)
        {
            _spawner[i] = transform.GetChild(i);
        }
        StartSpawning();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && IsInvoking("Spawn"))
        {
            StopSpawing();
        }else if (Input.GetKeyUp(KeyCode.R) && !IsInvoking("Spawn"))
        {
            StartSpawning();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            foreach (EnemieController t in EnnemiesList)
            {
                Debug.Log(t.Health);
            }
        }
    }
    public void StartSpawning()
    {
        InvokeRepeating("Spawn", _spawnStart, _interval);
    }

    public void StopSpawing()
    {
        CancelInvoke("Spawn");
    }

    public void Spawn()
    {
        Instantiate(EnemiesPrefab[Random.Range(0, _ennemyTypeCount)], _spawner[Random.Range(0, _spawnerCount)].position, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemieController obj))
        {
            EnnemiesList.Add(obj.GetComponent<EnemieController>());
            EnnemiesList.Last().WaveManagerRef = this;
        }
    }

}
