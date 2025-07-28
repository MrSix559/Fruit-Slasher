using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeTransform : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private Vector3 direction;

    private void Start()
    {
        _rb= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * _speed * Time.fixedDeltaTime);
    }
}
