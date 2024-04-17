using System;
using JUTPS.JUInputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Abilities
{
    public class FireballAttack : JUTPSActions.JUTPSAnimatedAction
    {
        // Outlets
        public string AnimationStateName;
        public Rigidbody fireballPrefab;
        private GameObject _camPivot;
        private AudioSource _audioSource;

        // Configuration
        public float fireDelay = 0.5f;
        public float fireballSpeed = 30f;
        public float fireSoundLingerTime = 1f;
        
        // State
        private float _fireTime;
        private float _fireSoundTime;
        private bool _canFire;
        private bool _isDampeningFireSound;
        private float _initialVolume;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _initialVolume = _audioSource.volume;
            _camPivot = cam.transform.parent.gameObject;
            SwitchAnimationLayer(ActionPart.FullBody);
        }

        // Called every frame
        public override void ActionCondition()
        {
            if (JUInput.GetButtonDown(JUInput.Buttons.ShotButton) && IsActionPlaying == false)
            {
                // Start action and play animation
                StartAction();
                PlayAnimation(AnimationStateName);
            }
        }

        // Called every frame while action is playing
        public override void OnActionIsPlaying()
        {
            TPSCharacter.FiringMode = false;
            TPSCharacter.transform.LookAt(_camPivot.transform.forward + TPSCharacter.transform.position);
            
            if (!_canFire) return;
            
            // Fireball attack
            if (_fireTime < 0)
            {
                PerformFireballAttack();
                _fireTime = fireDelay;
            }
            
            _fireTime -= Time.deltaTime;
        }

        // Called on action start
        public override void OnActionStarted()
        {
            TPSCharacter.CanMove = false;
            
            _audioSource.volume = _initialVolume;
            _audioSource.Play();
            _isDampeningFireSound = false;
        }

        // Called on action end
        public override void OnActionEnded()
        {
            _canFire = false;
            TPSCharacter.CanMove = true;
            
            _fireSoundTime = fireSoundLingerTime;
            _isDampeningFireSound = true;
        }

        public void PerformFireballAttack()
        {
            // Instantiate fireball
            var playerTransform = transform;
            var handTransform = anim.GetBoneTransform(HumanBodyBones.RightHand);
            var fireball = Instantiate(fireballPrefab, handTransform.position + playerTransform.forward, playerTransform.rotation);
            fireball.velocity = playerTransform.forward * fireballSpeed;
        }

        public void StartMagicAttack()
        {
            _canFire = true;
        }

        private void LateUpdate()
        {
            if (_isDampeningFireSound)
            {
                _fireSoundTime -= Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(0, 1, _fireSoundTime / fireSoundLingerTime);
                
                if (_fireSoundTime <= 0)
                {
                    _audioSource.Stop();
                    _isDampeningFireSound = false;
                }
            }
        }
    }
}