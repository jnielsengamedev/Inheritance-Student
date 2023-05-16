using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Weapon defaultWeapon;
    public Weapon equippedWeapon;
    public Transform weaponSlot;

    private Camera mainCamera;
    private Vector2 mousePos;

    private Vector2 movement;

    [SerializeField] private float health;
    public float maxHealth;

    public float Health
    {
        get => health;
        set
        {
            health = value;
            gameManager.healthDisplay.text = HealthDisplayText(value);
        }
    }


    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {
            moveSpeed = value;
            gameManager.speedDisplay.text = SpeedDisplayText(value);
        }
    }

    public GameManager gameManager;
    
    private static string SpeedDisplayText(float value) => $"Speed: {value}";

    private static string HealthDisplayText(float value) => $"Health: {value}";

    void Start()
    {
        mainCamera = Camera.main;

        EquipWeapon(defaultWeapon);


        // Set Health on the UI.
        gameManager.healthDisplay.text = HealthDisplayText(health);

        // Set Speed on the UI.
        gameManager.speedDisplay.text = SpeedDisplayText(moveSpeed);
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Get mouse position and calculate aim direction
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - (Vector2)transform.position).normalized;

        // Get starting rotation of player sprite
        Quaternion startingRotation = Quaternion.AngleAxis(90f, Vector3.forward);

        // Rotate player to face mouse position
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, lookDir) * startingRotation;
        transform.rotation = targetRotation;

        // Set aim direction of equipped weapon
        // equippedWeapon.SetAimDirection(aimDir);

        // Check for fire input
        if (Input.GetButtonDown("Fire1"))
        {
            equippedWeapon.Attack();
        }
    }

    void FixedUpdate()
    {
        // Move player based on movement input
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        equippedWeapon = Instantiate(newWeapon, weaponSlot.position, weaponSlot.rotation);
        equippedWeapon.transform.parent = weaponSlot.transform;
    }

    public void UnequipWeapon()
    {
        Destroy(equippedWeapon);
    }

    public void HealAllHealth()
    {
        health = maxHealth;
    }
}