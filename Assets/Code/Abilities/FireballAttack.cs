using JUTPS.JUInputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : JUTPSActions.JUTPSAnimatedAction
{
    [Header("Fireball Attack")]
    public string AnimationStateName;
    public GameObject MagicAttackParticle;

    void Start() { SwitchAnimationLayer(ActionPart.FullBody); }

    //Called every frame
    public override void ActionCondition()
    {
        if (JUInput.GetButtonDown(JUInput.Buttons.ShotButton) && IsActionPlaying == false)
        {
            //Start action and play animation
            StartAction();
            PlayAnimation(AnimationStateName);
        }
    }
    //Called every frame while action is playing
    public override void OnActionIsPlaying()
    {
        //Make the character look in front of the camera
        TPSCharacter.transform.LookAt(cam.transform.forward * 100);
    }

    //Called on action start
    public override void OnActionStarted()
    {
        //Store current item in use
        SetCurrentItemIndexToLastUsedItem();
    }
    //Called on action end
    public override void OnActionEnded()
    {
    }

    // >> Function to be called by JU Animation Event Receiver <<
    public void magicAttackFlame()
    {
        Vector3 spawnPos = anim.GetBoneTransform(HumanBodyBones.RightHand).position + transform.forward * 0.3f;
        GameObject magic_attack = Instantiate(MagicAttackParticle, spawnPos, transform.rotation, transform);
        Destroy(magic_attack, 10);
    }
}
