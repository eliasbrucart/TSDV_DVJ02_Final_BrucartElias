using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform tower;
    [SerializeField] private float towerSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private float distanceCamRay;

    private Vector3 mousePos;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, horizontal * Time.deltaTime * rotationSpeed, 0.0f);
        transform.Translate(0.0f, 0.0f, vertical * Time.deltaTime * speed);
    }

    void Shoot()
    {
        mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * distanceCamRay, Color.yellow);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distanceCamRay))
            {
                Debug.Log("Dio click en: " + hit.point);
                StartCoroutine(RotateTower(hit));
            }
        }
    }

    IEnumerator RotateTower(RaycastHit hit)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Funca esto");
        tower.LookAt(hit.point, Vector3.up);
    }
}
