using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Food _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _count;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _points;

    private float _timeToNextSpawn = 1f;
    private float _elapsedTime = 0f;
    private ObjectPool<Food> _pool;

    private void Start()
    {
        _pool = new ObjectPool<Food>(_prefab, _count, _container);
        _pool.GetAutoExpand(_autoExpand);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToNextSpawn)
        {
            if (_pool.TryGetObject(out Food food, _prefab))
            {
                int randomIndex = Random.Range(0,_points.Length);
                _elapsedTime = 0f;
                food.Dying += OnFoodDiyng;
                food.transform.position = _points[randomIndex].position;
            }
        }
    }

    public void ResetGame()
    {
        _pool.Reset();
    }

    private void OnFoodDiyng(Food food)
    {
        _player.IncreaseTail();
        food.Dying -= OnFoodDiyng;
    }
}