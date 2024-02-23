using UnityEngine;


// > inherit the JUTPSAnimatedAction class
public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    private Rigidbody rb;

    [Header("Dashing")]
    public float dashForce = 10f;
    private int dashForceMultiplier = 1000;
    public float dashDuration = 1.0f;
    private bool dashing = false;

    [Header("Cooldown")]
    public float dashCD = 1.0f;
    private float dashCDTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.Q;

    private void Start() 
    { 
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(dashKey))
        {
            Dash();
        }

        if(dashCDTimer >0)
        {
            dashCDTimer -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        
    }

    //Called every frame
    private void Dash()
    {
        if (dashCDTimer > 0) { return; }
        else dashCDTimer = dashCD;


        dashing = true;
        Vector3 forceToApply = orientation.forward * dashForce * dashForceMultiplier;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);


        Invoke(nameof(ResetDash), dashDuration);
    }

    private void ResetDash()
    {
        dashing = false;
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

}