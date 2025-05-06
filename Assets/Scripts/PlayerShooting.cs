using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        rb.velocity = new Vector2(direction * bulletSpeed, 0f);
        
        if (direction < 0)
        {
            Vector3 scale = bullet.transform.localScale;
            scale.x *= -1;
            bullet.transform.localScale = scale;
        }
    }
}