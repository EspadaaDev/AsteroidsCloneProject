using GameLogic;
using GameLogic.Architecture.Spaceships;
using GameLogic.Architecture.Weapons.Guns;
using GameLogic.Player;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    // Fields
    [SerializeField] private PlayerView playerView;
    [SerializeField] private GameObject bulletPrefab;
    Rigidbody2D rb;

    private Weapon[] guns;

    private void Start()
    {
        guns = new Weapon[] { new MachineGun(), new Laser() };
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && guns[0].Shot())
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 30f);
        }

        // Laser shot
        if (Input.GetKey(KeyCode.Mouse1) && guns[1].Shot())
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 30f);
        }
    }
}
