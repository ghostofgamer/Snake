using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;

    private readonly float _Offset = 10f;
    private readonly float _yOffset = 30f;

    private void Update()
    {
        transform.position = new Vector3(
            _player.transform.position.x - _Offset,
            _player.transform.position.y + _yOffset,
            _player.transform.position.z - _Offset
            );
    }
}
