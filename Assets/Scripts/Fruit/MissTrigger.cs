using System;
using UnityEngine;

public class MissTrigger : MonoBehaviour
{
    public static event Action OnFruitMiss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fruit>())
            OnFruitMiss?.Invoke();
    }
}
