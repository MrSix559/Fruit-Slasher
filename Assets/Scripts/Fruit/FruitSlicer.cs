using UnityEngine;

public class FruitSlicer : MonoBehaviour
{
    [SerializeField] private LayerMask _fruitLayer;
    [SerializeField] private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 MousePosition = Input.mousePosition;

            _ray = _camera.ScreenPointToRay(MousePosition);
            if (Physics.Raycast(_ray, out _hit, _fruitLayer))
            {
                if (_hit.collider != null && _hit.collider.transform.TryGetComponent<Fruit>(out Fruit fruit))
                    fruit.Slice();
            }
        }
    }
}
