using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        Destroy(gameObject, despawnTime);
    }
}
