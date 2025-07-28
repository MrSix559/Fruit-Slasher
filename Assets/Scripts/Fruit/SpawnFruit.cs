using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnFruit : MonoBehaviour
{
    [SerializeField] private List<PoolObjects<Fruit>> _poolList = new();

    [SerializeField] private Transform _fruitsParent;
    [SerializeField] private Fruit[] _fruitPrefabs;
    [SerializeField] private Transform _leftPositionBorder;
    [SerializeField] private Transform _rightPositionBorder;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _impulsePower;

    private Coroutine _spawningFruits;

    private void Awake()
    {
        foreach (var prefab in _fruitPrefabs)
            _poolList.Add(new PoolObjects<Fruit>(prefab, _fruitsParent, 3));
    }

    private void OnEnable()
    {
        MenuManager.OnStart += StartSpawn;
        GameManager.OnGameOver += StopSpawn;
        GameManager.OnRestart += StartSpawn;
    }

    private void OnDisable()
    {
        MenuManager.OnStart -= StartSpawn;
        GameManager.OnGameOver -= StopSpawn;
        GameManager.OnRestart -= StartSpawn;
    }

    private void StartSpawn()
    {
        _spawningFruits = StartCoroutine(FruitSpawning());
    }

    private void StopSpawn()
    {
        StopCoroutine(_spawningFruits);
    }

    private IEnumerator FruitSpawning()
    {
        WaitForSeconds secondsForSpawn = new WaitForSeconds(_spawnDelay);
        while (true)
        {
            yield return secondsForSpawn;
            Fruit fruit = _poolList[Random.Range(0, _poolList.Count)].Get();
            fruit.Spawn();
            float randPosition = Random.Range(0f, 1f);
            fruit.transform.position = Vector3.Lerp(_leftPositionBorder.position, _rightPositionBorder.position, randPosition);

            fruit.Rb.AddForce(Quaternion.Lerp(_leftPositionBorder.rotation, _rightPositionBorder.rotation, randPosition) * Vector3.up * _impulsePower, ForceMode.Impulse);
            DOTween.Sequence().AppendInterval(6f).AppendCallback(() => { fruit.ResetFruit(); fruit.gameObject.SetActive(false); });
        }
    }
}
