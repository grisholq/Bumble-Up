using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private Stack<GameObject> _instances;

    private void Start()
    {
        _instances = new Stack<GameObject>();
    }

    public GameObject Get()
    {
        if(_instances.Count == 0)
        {
            return Instantiate(_prefab);
        }

        var instance = _instances.Pop();
        instance.SetActive(true);
        return instance;
    }

    public void Release(GameObject instance)
    {
        instance.SetActive(false);
        _instances.Push(instance);
    }
}
