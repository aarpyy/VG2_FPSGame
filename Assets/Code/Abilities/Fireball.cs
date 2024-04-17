using JUTPS;
using UnityEngine;

namespace Code.Abilities
{
    public class Fireball : MonoBehaviour
    {
        // Configuration
        public float timeToLive = 5f;
        public float damage = 10f;

        private void OnTriggerEnter(Collider other)
        {
            // If it hit a player
            if (other.CompareTag("Enemy"))
            {
                var character = other.GetComponent<JUCharacterController>();
                if (character != null)
                {
                    // Do damage
                    character.TakeDamage(damage);
                }
            }

            if (!other.CompareTag("Bullet"))
            {
                // Destroy the fireball
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            // Destroy the fireball after a certain amount of time
            timeToLive -= Time.deltaTime;
            if (timeToLive <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}