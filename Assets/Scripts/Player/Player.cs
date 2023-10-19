using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Tail _tail;

    private List<Tail> _tails = new List<Tail>();

    public List<Tail> Tails => _tails;
    public bool Die { get; private set; } = false;

    private void Start()
    {
        IncreaseTail();
    }

    public void IncreaseTail()
    {
        Tail tail = Instantiate(_tail);
        _tails.Add(tail);
    }
}
