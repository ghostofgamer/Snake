using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    public event UnityAction<Food> Dying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.IncreaseTail();
            Die();
        }
    }

    public void Die()
    {
        Dying?.Invoke(this);
        gameObject.SetActive(false);
    }
}
