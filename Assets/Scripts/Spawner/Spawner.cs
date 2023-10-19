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

    private static float _timeToNextSpawn = 3f;
    private float _elapsedTime = 0f;
    private ObjectPool<Food> _pool;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_timeToNextSpawn);

    private void Start()
    {
        _pool = new ObjectPool<Food>(_prefab, _count, _container);
        _pool.GetAutoExpand(_autoExpand);
        StartCoroutine(SpawnFood());
    }

    private IEnumerator SpawnFood()
    {
        while (!_player.Die)
        {
            if (_pool.TryGetObject(out Food food, _prefab))
            {
                GetPosition(food);
            }

            yield return _waitForSeconds;
        }
    }

    public void ResetGame()
    {
        _pool.Reset();
    }

    private void GetPosition(Food food)
    {
        int randomIndex = Random.Range(0, _points.Length);
        food.transform.position = _points[randomIndex].position;
        food.Dying += OnFoodDiyng;
    }

    private void OnFoodDiyng(Food food)
    {
        _player.IncreaseTail();
        food.Dying -= OnFoodDiyng;

        if (_pool.TryGetObject(out Food newFood, _prefab))
            GetPosition(newFood);
    }
}