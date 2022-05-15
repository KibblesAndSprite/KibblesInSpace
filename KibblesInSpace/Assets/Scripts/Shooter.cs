using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] [Range(0, 50)] int _poolSize = 20;
    [SerializeField] [Range(0.1f, 30f)] float _spawnTime = 1f;

    GameObject[] _poolGameObjects;
    bool _isFireing = false; // will hopfullt be changed to an event 


    // Start is called before the first frame update
    void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        _isFireing = true; // THIS NEEDS TO BE REMOVED. WILL CHANGE!
        StartCoroutine(Fire());
    }

    void PopulatePool()
    {
        _poolGameObjects = new GameObject[_poolSize];

        for (int i = 0; i < _poolGameObjects.Length; i++)
        {
            _poolGameObjects[i] = Instantiate(_projectilePrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation);
            _poolGameObjects[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < _poolGameObjects.Length; i++)
        {
            if (_poolGameObjects[i].activeInHierarchy == false)
            {
                _poolGameObjects[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator Fire()
    {
        while (_isFireing)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
