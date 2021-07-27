using GameLogic.Architecture.Weapons.Guns;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    // Fields
    [SerializeField] private PlayerView playerView;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laserRayPrefab;
    [SerializeField] private LineRenderer lineRenderer;

    private Rigidbody2D rb;

    // Weapons
    public Laser Laser { get; private set; }
    public MachineGun MachineGun { get; private set; }


    private void Awake()
    {
        Laser = new Laser();
        MachineGun = new MachineGun();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        Laser.AddShot(Time.deltaTime / 3f);
    }
    private void Update()
    {
        Shooting();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) && rb.angularVelocity < 150f) { rb.AddTorque(0.5f); }
        if (Input.GetKey(KeyCode.D) && rb.angularVelocity > -150f) { rb.AddTorque(-0.5f); }
        if (Input.GetKey(KeyCode.W)) { rb.AddForce(transform.up * 5f); }

        if (rb.angularVelocity > 200f) { rb.angularVelocity = 200f; }
        if (rb.angularVelocity < -200f) { rb.angularVelocity = -200f; }
        if (rb.velocity.magnitude > 4f) { rb.velocity = rb.velocity.normalized  * 4f; }
    }

    private void Shooting()
    {
        // MachineGun shot
        if (Input.GetKeyDown(KeyCode.Mouse0) && MachineGun.Shot())
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 30f);
        }

        // Laser shot
        if (Input.GetKey(KeyCode.Mouse1) && Laser.Shot())
        {
            var laserRay = Instantiate(laserRayPrefab, transform.position, transform.rotation);
            laserRay.GetComponent<Rigidbody2D>().AddForce(transform.up * 50f);
        }
    }
}
