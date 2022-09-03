using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public GameObject bodyPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit))
            {
                Instantiate(bodyPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
