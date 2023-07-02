using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public static PlayerJump instance;
    private Rigidbody myBody;
    private Animator Anim;
    [SerializeField]
    private float forceForwd, forceUp,Angle;
    public float threshHoldFwd, threshHoldUp, maxJumpForceF, maxJumpForceUp,
                  AngThress, MaxL, MaxR;

    private bool setPower,setAngleL,setAngleR;
    public GameObject AngLBtn, AngRBtn, JumpBtn;

    private void Awake()
    {
        MakeInstance();
        myBody = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        JumpBtn.SetActive(false);
        AngLBtn.SetActive(true);
        AngRBtn.SetActive(true);
    }
    private void Update()
    {
        SetPower();
        SetAngleL();
        SetAngleR();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void SetPower()
    {
        if (setPower)
        {
            forceForwd -= threshHoldFwd * Time.deltaTime;
            forceUp += threshHoldUp * Time.deltaTime;

            if (forceForwd < maxJumpForceF)
            {
                forceForwd = maxJumpForceF;
            }
            if (forceUp > maxJumpForceUp)
            {
                forceUp = maxJumpForceUp;
            }

            Anim.SetBool("Sit", true);
            Anim.SetBool("Jump", false);
        }
    }
    private void Jump()
    {
        myBody.AddForce(transform.forward * forceForwd,ForceMode.Impulse);
        myBody.AddForce(transform.up * forceUp,ForceMode.Impulse);
        forceForwd = forceUp = 0;
       
        PrepRotate();
        Anim.SetBool("Sit", false);
        Anim.SetBool("Jump", true);
    }

    public void SetPower(bool setPower)
    {
        this.setPower = setPower;
        if (!setPower)
        {
            Jump();
        }
    }



    private void SetAngleL()
    {
        if (setAngleL)
        {
            Angle -= AngThress * Time.deltaTime;
            gameObject.transform.localEulerAngles = new Vector3(0, Angle, 0);
            
            if (Angle < MaxL)
            {
                Angle = MaxL;
            }
           
        }
    }
    public void SetAngleL(bool setAngleL)
    {
        this.setAngleL = setAngleL;
        if (!setAngleL)
        {
            PrepJump();
        }
    }
    private void SetAngleR()
    {
        if (setAngleR)
        {
            Angle += AngThress * Time.deltaTime;
            gameObject.transform.localEulerAngles = new Vector3(0, Angle, 0);
            if (Angle > MaxR)
            {
                Angle = MaxR;
            }

        }
    }
    public void SetAngleR(bool setAngleR)
    {
        this.setAngleR = setAngleR;
        if (!setAngleR)
        {
            PrepJump();
        }
    }
    private void PrepRotate()
    {
        JumpBtn.SetActive(false);
        AngLBtn.SetActive(true);
        AngRBtn.SetActive(true);
    }

    private void PrepJump()
    {
        JumpBtn.SetActive(true);
        AngLBtn.SetActive(false);
        AngRBtn.SetActive(false);
    }
 
}
