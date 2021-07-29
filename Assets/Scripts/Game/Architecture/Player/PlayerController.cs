using GameLogic.Architecture.Weapons.Guns;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laserRayPrefab;
    [Header("Laser settings:")]
    [SerializeField] private int maxShots = 3;
    [SerializeField] private float timeToReload = 0.3f;
    [SerializeField] private float addShotTime = 3.0f;
    private Rigidbody2D rb;
    public event Action GameOverNotify;

    // Weapons
    public Laser Laser { get; private set; }
    public MachineGun MachineGun { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameOver();
        }
    }
    private void Awake()
    {
        Laser = new Laser(maxShots, timeToReload, addShotTime);
        MachineGun = new MachineGun();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ApplicationData.Instance.GameIsOn)
        {
            Movement();
            Laser.TimeFlow(Time.deltaTime);
        }
    }
    private void Update()
    {
        if (ApplicationData.Instance.GameIsOn && !EventSystem.current.IsPointerOverGameObject())
        {
            Shooting();
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) && rb.angularVelocity < 150f) { rb.AddTorque(0.5f); }
        if (Input.GetKey(KeyCode.D) && rb.angularVelocity > -150f) { rb.AddTorque(-0.5f); }
        if (Input.GetKey(KeyCode.W)) { rb.AddForce(transform.up * 5f); }

        if (rb.angularVelocity > 200f) { rb.angularVelocity = 200f; }
        if (rb.angularVelocity < -200f) { rb.angularVelocity = -200f; }
        if (rb.velocity.magnitude > 4f) { rb.velocity = rb.velocity.normalized * 4f; }
    }

    private void Shooting()
    {
        // MachineGun shot
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (MachineGun.Shot())
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 30f);
            }
        }

        // Laser shot
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Laser.Shot())
            {
                var laserRay = Instantiate(laserRayPrefab, transform.position, transform.rotation);
                laserRay.GetComponent<Rigidbody2D>().AddForce(transform.up * 50f);
            }
        }
    }
    public void GameOver()
    {
        GameOverNotify?.Invoke();
    }
}
