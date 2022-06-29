using UnityEngine;

public class Player_Control : MonoBehaviour
{

    public float Speed = 5f;
    public float TurnSpeed = 10f;
    public float TurnDeg = 0.25f;
    public float BoostSpeed = 2f;

    public Quaternion Rotate;

    private bool Moving = false;
    private bool Turning = false;


    private Rigidbody2D _rigidbody;
    public Animator animator;

    Vector2 movement;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Rotate = _rigidbody.transform.rotation;
        // animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal")) {
            Turning = true;
        } else if (Input.GetButtonUp("Horizontal")) {
            Turning = false;
        }
        if (Input.GetButtonDown("Vertical")) {
            Moving = true;
        } else if (Input.GetButtonUp("Vertical")) {
            Moving = false; 
        }



        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0) {
            animator.SetBool("Idle", true);
        } else {
            animator.SetBool("Idle", false);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // var impulse = ((-1 * x) * Mathf.Deg2Rad) * _rigidbody.inertia;
        var impulse = ((TurnDeg * -x) * Mathf.Deg2Rad) * _rigidbody.inertia;

        // TurnSpeed = _rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg;
        // float p = _rigidbody.GetRelativePoint((0, y));

        if (Turning) {
            // Rotate.z = Quaternion(0, 0, TurnSpeed * x);
            _rigidbody.AddTorque(impulse, ForceMode2D.Impulse);
        }
        if (Moving) {
            _rigidbody.AddForce(transform.up * Speed * y);
        }

    }

    void Move() {
        
    }

}
