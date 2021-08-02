using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }

    private void LateUpdate()
    {
        float distance = Vector3.Distance(player.transform.position + offset, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, (cameraSpeed * distance) * Time.deltaTime);
    }
}
