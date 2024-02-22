using UnityEngine;
// > Import JU Input System Lib
using JUTPS.JUInputSystem;

// > inherit the JUTPSAnimatedAction class
public class DoubleJump : JUTPSActions.JUTPSAnimatedAction
{
    [Header("Double Jump")]
    public string AnimationStateName;
    public float jumpForce = 1.0f;
    public bool isGrounded;
    public float doubleJumpCD = 3f;
    public float doubleJumpTimer;

    void Start() { SwitchAnimationLayer(ActionPart.FullBody); }
    bool IsGrounded()
    {
        return rb.velocity.y == 0;
    }
    //Called every frame
    public override void ActionCondition()
    {
        Debug.Log("Double jump");
        isGrounded = IsGrounded();
        if (JUInput.GetButtonDown(JUInput.Buttons.JumpButton) && !IsGrounded() && IsActionPlaying==false && doubleJumpTimer <= 0)
        {
            Debug.Log("Jumping");
            //Start action and play animation
            StartAction();
            PlayAnimation(AnimationStateName);
            doubleJumpTimer = doubleJumpCD;
        }
        if(doubleJumpTimer > 0)
        {
            doubleJumpTimer -= Time.deltaTime;
        }
    }
    //Called every frame while action is playing
    public override void OnActionIsPlaying()
    {
        rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
    }
    public override void OnActionEnded()
    {
    }

    // >> Function to be called by JU Animation Event Receiver <<
    public void doubleJump()
    {
    }
}