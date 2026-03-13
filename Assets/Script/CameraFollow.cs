using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -20f);

    void LateUpdate()
    {
        if (target == null) return;

        // Yumuþak geçiþi sildik, kamera direkt hedefe yapýþacak
        transform.position = target.position + target.TransformDirection(offset);
        transform.LookAt(target);
    }
}