using UnityEngine;
// > Import JU Input System Lib
using JUTPS.JUInputSystem;

// > inherit the JUTPSAnimatedAction class
public class MagicAttackFlame : JUTPSActions.JUTPSAnimatedAction
{
    [Header("Magic Attack Flame")]
    public string AnimationStateName;
    public GameObject MagicAttackParticle;

    void Start() { SwitchAnimationLayer(ActionPart.FullBody); }

    //Called every frame
    public override void ActionCondition()
    {
        if (JUInput.GetButtonDown(JUInput.Buttons.AimingButton) && IsActionPlaying == false)
        {
            //Start action and play animation
            StartAction();
            PlayAnimation(AnimationStateName);
        }
    }
    //Called every frame while action is playing
    public override void OnActionIsPlaying()
    {
        //Force NO FiringMode
        TPSCharacter.FiringMode = false;
        //Make character fly
        rb.velocity = transform.up * 4;
        //Make the character look in front of the camera
        TPSCharacter.transform.LookAt(cam.transform.forward * 100);
    }

    //Called on action start
    public override void OnActionStarted()
    {
        //Store current item in use
        SetCurrentItemIndexToLastUsedItem();
        //Disable Item
        DisableItemOnHand();
    }
    //Called on action end
    public override void OnActionEnded()
    {
        //Re-equip last used item
        EnableLastUsedItem();
    }

    // >> Function to be called by JU Animation Event Receiver <<
    public void magicAttackFlame()
    {
        Vector3 spawnPos = anim.GetBoneTransform(HumanBodyBones.RightHand).position + transform.forward * 0.3f;
        GameObject magic_attack = Instantiate(MagicAttackParticle, spawnPos, transform.rotation, transform);
        Destroy(magic_attack, 10);
    }
}