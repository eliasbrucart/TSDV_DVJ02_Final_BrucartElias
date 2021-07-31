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
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Shoot();
    }

    private void LateUpdate()
    {
        MovePlayer();
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
