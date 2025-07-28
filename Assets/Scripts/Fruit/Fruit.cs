using System;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public static event Action OnSlice;

    [SerializeField] private Vector2 _rotationVelocity;
    [SerializeField] private Rigidbody[] _partsFruit;
    [SerializeField] private UnityEvent _onSlice;
    [SerializeField] private UnityEvent _onReset;
    [SerializeField] private UnityEvent _OnSpawn;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;
    public Rigidbody Rb => _rb;
    private Vector3[] _partsPositions;
    private Quaternion[] _partsRotation;

    private void Awake()
    {
        _partsPositions = new Vector3[_partsFruit.Length];
        _partsRotation = new Quaternion[_partsFruit.Length];
        for (int i = 0; i < _partsFruit.Length; i++)
        {
            _partsPositions[i] = _partsFruit[i].transform.localPosition;
            _partsRotation[i] = _partsFruit[i].transform.localRotation;
        }
    }

    public void Spawn()
    {
        _OnSpawn?.Invoke();
        _rb.angularVelocity = new Vector3(UnityEngine.Random.Range(_rotationVelocity.x, _rotationVelocity.y), UnityEngine.Random.Range(_rotationVelocity.x, _rotationVelocity.y), UnityEngine.Random.Range(_rotationVelocity.x, _rotationVelocity.y));
    }

    public void Slice()
    {
        OnSlice?.Invoke();
        _onSlice?.Invoke();
        foreach (var part in _partsFruit)
            part.gameObject.SetActive(true);
    }

    public void ResetFruit()
    {
        _rb.linearVelocity = Vector3.zero;
        for (int i = 0; i < _partsFruit.Length; i++)
        {
            _partsFruit[i].transform.localPosition = _partsPositions[i];
            _partsFruit[i].transform.localRotation = _partsRotation[i];
            _partsFruit[i].linearVelocity = Vector3.zero;
            _partsFruit[i].gameObject.SetActive(false);
        }

        _onReset?.Invoke();
    }
}
