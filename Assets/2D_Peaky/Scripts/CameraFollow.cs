using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float followSpeed = 2f;


    private void LateUpdate()
    {
        if (cameraTarget != null)
        {
            CameraFollowTarget();
        }
    }


    private void CameraFollowTarget()
    {

        Vector3 targetPosition = cameraTarget.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

    }
}
