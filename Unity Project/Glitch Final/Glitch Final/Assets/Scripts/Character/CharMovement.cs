using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharMovement: MonoBehaviour {

    private static CharMovement m_instance;

    public static CharMovement Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }

    //Variables held in private, but called upon by 'get' and 'set' in their independant properties
    private float m_fSpeed;
    public float Speed { get { return m_fSpeed; } set { m_fSpeed = value; } }
    private float m_fJumpSpeed;
    public float JumpSpeed { get { return m_fJumpSpeed; } set { m_fJumpSpeed = value; } }
    private float m_fGravity = 20.0f;
    public float Gravity { get { return m_fGravity; } set { m_fGravity = value; } }
    private Vector3 moveDirection = Vector3.zero;
    private float m_fHeight = 2.0f;
    public float Height { get { return m_fHeight; } set { m_fHeight = value; } }

    private CharacterController m_controller;
    private CapsuleCollider m_collider;

    //Animaiton Vars
    [SerializeField] private Animator m_Anim;
    private float m_fXAxisChange = 0;
    private float m_fLastFrameXPos = 0;

    void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_collider = GetComponent<CapsuleCollider>();
        m_Anim.SetBool("Running", false);
        m_Anim.SetBool("RunningB", false);
        m_Anim.SetBool("Jump", false);
        m_Anim.SetBool("Idle", true);
        UpdateSpeed();
    }
	// Update is called once per frame
    bool faceLeft = false;
	void Update ()
	{
	    m_fXAxisChange = m_fLastFrameXPos - transform.position.x;
	    m_fLastFrameXPos = transform.position.x;

	    float mouseX = Input.mousePosition.x;
	    float playerScreenX = Camera.main.WorldToScreenPoint(transform.position).x;
	    
	    faceLeft = mouseX < playerScreenX;

	    transform.eulerAngles = faceLeft ? new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z) : new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        //Checks to see if the character controller is on the ground before running the script
        if (m_controller.isGrounded)
        {
            m_Anim.SetBool("Jump", false);
            if(!faceLeft)
            {
                if (m_fXAxisChange < 0)
                {
                    m_Anim.SetBool("Running", true);
                    m_Anim.SetBool("RunningB", false);
                    m_Anim.SetBool("Idle", false);
                }
                else if (m_fXAxisChange > 0)
                {
                    m_Anim.SetBool("Running", false);
                    m_Anim.SetBool("RunningB", true);
                    m_Anim.SetBool("Idle", false);
                }
                else
                {
                    m_Anim.SetBool("RunningB", false);
                    m_Anim.SetBool("Running", false);
                    m_Anim.SetBool("Idle", true);
                }
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0);
                moveDirection = transform.TransformDirection(moveDirection); 
            }
            else
            {

                if (m_fXAxisChange < 0)
                {
                    m_Anim.SetBool("RunningB", true);
                    m_Anim.SetBool("Running", false);
                    m_Anim.SetBool("Idle", false);
                }
                else if (m_fXAxisChange > 0)
                {
                    m_Anim.SetBool("RunningB", false);
                    m_Anim.SetBool("Running", true);
                    m_Anim.SetBool("Idle", false);
                }
                else
                {
                    m_Anim.SetBool("RunningB", false);
                    m_Anim.SetBool("Running", false);
                    m_Anim.SetBool("Idle", true);
                }
                //correct input for the moveDirection will illicit a response
                moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0);
                moveDirection = transform.TransformDirection(moveDirection);
                //it is then multiplied by the Speed variable property
            }      
            
            moveDirection *= Speed;
            //if the input is the jump key
            if (Input.GetButtonDown("Jump"))
            {
                m_Anim.SetBool("Idle", false);
                m_Anim.SetBool("Jump", true);
                moveDirection.y = JumpSpeed;
            }
        }
        //this applies gravity to the character controller
        moveDirection.y -= Gravity * Time.deltaTime;
        //and this makes the character actually move
        m_controller.Move(moveDirection * Time.deltaTime);
	}

    public void UpdateSpeed()
    {
        //get agility stat
        //get weight stat
        //get strength stat

        //get percentage increase/decrease of agility, strength and weight
        //work out total percentage change
        //apply percentage change to base speed (6)
        //

        float baseSpeed = CharacterStats.Instance.BaseSpeed;
        int currentAgility = PlayerSkills.Instance.AgilitySkill;
        int currentWeight = WeaponController.Instance.CurrentWeapon == null ? 0 : WeaponController.Instance.CurrentWeapon.m_iWeight;
        int currentStrength = PlayerSkills.Instance.StrengthSkill;

        float percentageIncrease = ((baseSpeed*0.03f)*currentAgility);

        currentWeight -= currentStrength;
        if (currentWeight < 0)
        {
            currentWeight = 0;
        }
        float percentageDecrease = ((baseSpeed*0.03f)*currentWeight);
        float percentageChange = percentageIncrease - percentageDecrease;
        Speed = baseSpeed + percentageChange;
        if (Speed < 0) Speed = 0;
        JumpSpeed = Speed;
        


    }
}
