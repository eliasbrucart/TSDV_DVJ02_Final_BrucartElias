using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform tower;
    [SerializeField] private float towerSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private float distanceCamRay;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject barrel;

    private Vector3 mousePos;
    private float maxTimeAnim = 0.5f;
    private float timerAnim;

    private BoxCollider colliderTank;
    private float halfHeight;
    private float horizontal;
    private float vertical;

    public float distanceTraveled;

    void Start()
    {
        cam = Camera.main;
        colliderTank = GetComponent<BoxCollider>();
        halfHeight = colliderTank.bounds.extents.y;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
            MovePlayer();
        Shoot();
    }

    private void MovePlayer()
    {
        transform.Rotate(0.0f, horizontal * Time.deltaTime * rotationSpeed, 0.0f);
        transform.Translate(0.0f, 0.0f, vertical * Time.deltaTime * speed);

        distanceTraveled = distanceTraveled + speed * Time.deltaTime;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -transform.up, out hitInfo))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation, 0.15f);
            transform.position = hitInfo.point + hitInfo.normal * halfHeight;
        }
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
                StartCoroutine(RotateTower(hit));
            }
        }
    }

    IEnumerator RotateTower(RaycastHit hit)
    {
        while (timerAnim < maxTimeAnim)
        {
            timerAnim += Time.deltaTime;
            Quaternion targetRotation = Quaternion.identity;
            Vector3 targetDirection = (hit.point - tower.position).normalized;
            targetRotation = Quaternion.LookRotation(targetDirection);
            tower.rotation = Quaternion.SlerpUnclamped(tower.rotation, targetRotation, towerSpeed);
            yield return null;
        }
        Instantiate(bombPrefab, barrel.transform.position, tower.rotation);
        timerAnim = 0;
    }
}
