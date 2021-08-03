using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private Rigidbody rb;

    public static event Action CollisionWithBox;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        Destroy(gameObject, despawnTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box")
        {
            Destroy(collision.gameObject);
            CollisionWithBox?.Invoke();
            Destroy(gameObject);
        }
    }
}
