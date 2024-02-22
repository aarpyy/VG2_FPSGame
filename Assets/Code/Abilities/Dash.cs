using UnityEngine;
// > Import JU Input System Lib
using JUTPS.JUInputSystem;

// > inherit the JUTPSAnimatedAction class
public class Dash : JUTPSActions.JUTPSAnimatedAction
{
    [Header("Dash")]
    public Transform orientation;
    public string AnimationStateName;
    public float dashForce = 1.0f;
    public float dashUpwardForce = 1.0f;
    public float dashDuration = 3.0f;
    public float dashCD = 1.0f;
    private float dashCDTimer;

    void Start() { SwitchAnimationLayer(ActionPart.Legs); }

    //Called every frame
    public override void ActionCondition()
    {

        if (JUInput.GetButtonDown(JUInput.Buttons.RollButton) && IsActionPlaying==false)
        {
            //Start action and play animation
            StartAction();
            PlayAnimation(AnimationStateName);
        }
    }
    //Called every frame while action is playing
    public override void OnActionIsPlaying()
    {
        Debug.Log("Dashing");
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashForce;
        //Make character fly
        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);
        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }
    private void ResetDash() { }
    public override void OnActionEnded()
    {
    }

    // >> Function to be called by JU Animation Event Receiver <<
    public void dash()
    {
    }
}