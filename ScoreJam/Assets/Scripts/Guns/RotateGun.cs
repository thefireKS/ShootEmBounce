using UnityEngine;

public class RotateGun : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float minDistance;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var width = Screen.width / 2;
        var height = Screen.height / 2;
        Vector3 screenPoint = new Vector3(width, height, 0);
        
        Ray ray = _camera.ScreenPointToRay(screenPoint);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.distance >= minDistance)
            {
                transform.LookAt(hit.point);
            }
        }
        else
        {
            transform.rotation = _camera.transform.rotation;
        }
    }
}
