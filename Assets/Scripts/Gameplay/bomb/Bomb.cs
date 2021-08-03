using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private Rigidbody rb;
    private bool alreadyCollision;

    public static event Action CollisionWithBox;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        Destroy(gameObject, despawnTime);
        alreadyCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box" && !alreadyCollision)
        {
            Destroy(collision.gameObject);
            CollisionWithBox?.Invoke();
            alreadyCollision = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "terrain")
            Destroy(gameObject);
    }
}
