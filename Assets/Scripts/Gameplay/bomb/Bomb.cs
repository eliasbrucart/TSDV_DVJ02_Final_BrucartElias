using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player.ShootEvent += MoveBomb;
    }

    void Update()
    {
        
    }

    private void MoveBomb()
    {
        rb.AddForce(transform.forward * speed);
        DestroyBomb();
    }

    private void DestroyBomb()
    {
        Destroy(gameObject, despawnTime);
    }

    private void OnDisable()
    {
        Player.ShootEvent -= MoveBomb;
    }
}
