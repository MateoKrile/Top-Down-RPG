using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float damage = 20f;
        float timeSinceLastAttack = 0;
        Health currentTarget;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if(currentTarget == null) { return; }
            if(currentTarget.IsDead()) { return; }
            if(!GetIsInRange())
            {
                GetComponent<Mover>().StartMoveAction(currentTarget.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }
        private void AttackBehaviour()
        {
            transform.LookAt(currentTarget.transform);
            GetComponent<Animator>().SetTrigger("attack");
            if(timeBetweenAttacks < timeSinceLastAttack)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }
        public void Attack(GameObject target)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            currentTarget = target.GetComponent<Health>();
        }
        public void Cancel()
        {
            currentTarget = null;
        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, currentTarget.transform.position) < weaponRange;
        }
        void Hit()
        {
            if(currentTarget == null) { return; }
            currentTarget.TakeDamage(damage);
        }
        public bool CanAttack(GameObject target)
        {
            if(target == null) { return false; }  
            Health targetHealth = target.GetComponent<Health>();
            return targetHealth != null && !targetHealth.IsDead();
        }
    }
}