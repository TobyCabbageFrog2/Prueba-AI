using UnityEngine;

public class plaMov : MonoBehaviour
{
   
    private Transform Cam;
    public Rigidbody Rb;
    public GameObject Gun;
    public GameObject Bazooka;

    public GameObject menuCanvas;

    public float Speed = 10f;
    public float veSpeed = 10f;
    public bool isRunning = false;
    public float currentSpeed;
    public Transform Pla;

    public float movementX;
    public float movementY;


    public float jumpForce = 10f;




    Vector3 velocity;
    public Transform GroundCheck;
    public float ListenerRad = 0.3f;
    public LayerMask Ground;
    public bool isGrounded;

    public Vector2 sensibilidadMouse;


    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Cam = GetComponentInChildren<Camera>().transform;

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, ListenerRad, Ground);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Rb.linearVelocity = new Vector3(Rb.linearVelocity.x, jumpForce, Rb.linearVelocity.z);
        }

        Movement();
        MouseLook();
    }

    void Movement()

    {

        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        currentSpeed = isRunning ? veSpeed : Speed;

        Vector3 direccion = (transform.forward * movementY + transform.right * movementX).normalized;
        Vector3 movimiento = direccion * currentSpeed;
        movimiento.y = Rb.linearVelocity.y;

        Rb.linearVelocity = movimiento;
    }

    void MouseLook()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        if (moveX != 0)

        {
            transform.Rotate(0, moveX * sensibilidadMouse.x, 0);
        }

        if (moveY != 0)

        {
            Cam.Rotate(-moveY * sensibilidadMouse.y, 0, 0);
        }
    }
}
