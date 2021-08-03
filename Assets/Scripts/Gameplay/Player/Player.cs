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
    [SerializeField] private GameObject crossfire;
    [SerializeField] private float crossfireOffset;

    private Vector3 mousePos;
    private float maxTimeAnim = 0.5f;
    private float timerAnim;

    private BoxCollider colliderTank;
    private float halfHeight;
    private Transform chasis;
    void Start()
    {
        cam = Camera.main;
        colliderTank = GetComponent<BoxCollider>();
        halfHeight = colliderTank.bounds.extents.y;
        chasis = GetComponent<Transform>();
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }

    private void LateUpdate()
    {
        
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, horizontal * Time.deltaTime * rotationSpeed, 0.0f);
        //chasis.rotation = Quaternion.LookRotation(Vector3.right);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        transform.Translate(0.0f, 0.0f, vertical * Time.deltaTime * speed);

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
        //crossfire.transform.position = ray.origin + (ray.direction * (distanceCamRay - crossfireOffset));
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
        while(timerAnim < maxTimeAnim)
        {
            timerAnim += Time.deltaTime;
            Quaternion targetRotation = Quaternion.identity;
            Vector3 targetDirection = (hit.point - tower.position).normalized;
            targetRotation = Quaternion.LookRotation(targetDirection);
            tower.rotation = Quaternion.SlerpUnclamped(tower.rotation, targetRotation, towerSpeed);
            yield return null;
        }
        timerAnim = 0;
    }
}
