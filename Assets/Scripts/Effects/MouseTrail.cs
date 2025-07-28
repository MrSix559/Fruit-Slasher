using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _zOffset = 10f;

    private void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = _zOffset;

        Vector3 worldPos = _camera.ScreenToWorldPoint(mouseScreenPos);
        transform.position = worldPos;
    }
}
