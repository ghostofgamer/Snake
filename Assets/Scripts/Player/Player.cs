using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Tail _tail;

    private List<Tail> _tails = new List<Tail>();

    private List<Vector3> _positionHistory = new List<Vector3>();
    private int _gap = 15;

    private void Start()
    {
        IncreaseTail();
        IncreaseTail();
        IncreaseTail();
        IncreaseTail();
        IncreaseTail();
    }

    private void Update()
    {
        _positionHistory.Insert(0, transform.position);
        int index = 0;

        foreach (var tail in _tails)
        {
            Vector3 point = _positionHistory[Mathf.Min(index * _gap, _positionHistory.Count - 1)];
            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * 15 * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }
    }

    public void IncreaseTail()
    {
        Tail tail = Instantiate(_tail);
        _tails.Add(tail);
    }
}
