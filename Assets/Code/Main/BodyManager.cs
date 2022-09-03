using UnityEngine;

public class BodyManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit))
            {
                var temp = ObjectPool.SharedInstance.GetPooledObject();
                if (temp != null)
                {
                    temp.transform.position = hit.point;
                    temp.transform.rotation = Quaternion.identity;
                    temp.SetActive(true);
                }
            }
        }
    }
}
