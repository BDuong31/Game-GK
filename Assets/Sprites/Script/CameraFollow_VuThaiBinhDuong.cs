// CameraFollow_VuThaiBinhDuong.cs
using UnityEngine;

public class CameraFollow_VuThaiBinhDuong : MonoBehaviour
{
    public Transform player_VuThaiBinhDuong;

    public Vector3 offset = new Vector3(0f, 1f, -10f);

    [Range(0.01f, 1.0f)]
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player_VuThaiBinhDuong == null)
        {
            Debug.LogWarning("Camera Follow: Player transform not assigned!");
            return;
        }

        Vector3 desiredPosition = player_VuThaiBinhDuong.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}