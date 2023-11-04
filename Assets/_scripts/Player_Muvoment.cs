using UnityEngine;

public class Player_Muvoment : MonoBehaviour
{
    private CharacterController cc;
    public Animator shake;
    public float graviry = -9.8f;
    public float speed = 15.0f;
    public float sprint = 20;
    private bool statusSprint;
    private float jspeed = 0.0f;
    public float jumpForce = 15;
    public bool CanMove = true;
    // Vector3 moveVelocity;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (cc.isGrounded)
        {
            jspeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jspeed = jumpForce;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            statusSprint = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            statusSprint = false;
        }

        if (statusSprint)
        {
            horizontal = Input.GetAxis("Horizontal") * sprint;
            vertical = Input.GetAxis("Vertical") * sprint;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal") * speed;
            vertical = Input.GetAxis("Vertical") * speed;
        }
        if (!CanMove)
        {
            horizontal = 0;
            vertical = 0;
        }
        Func(horizontal, vertical);
        jspeed += graviry * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(horizontal, jspeed, vertical);
        dir *= Time.deltaTime;
        dir = transform.TransformDirection(dir);
        cc.Move(dir);
        

    }
    public void Func(float horizontal , float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            shake.SetTrigger("Status");
            shake.enabled = true;
        }
        else
        {
            shake.enabled = false;
        }
    }
    public void setCanMove(bool CM)
    {
        CanMove = CM;
    }
}
