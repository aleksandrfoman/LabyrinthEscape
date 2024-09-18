using System;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerHealth
    {
        public event Action OnDead;
        [SerializeField] private float health;
        private float curHealth;

        public void Init()
        {
            curHealth = health;
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                OnDead?.Invoke();
            }
        }
    }
}
