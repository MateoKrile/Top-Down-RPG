using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 1f;
        CombatTarget currentTarget;
        private void Update()
        {
            if(!currentTarget) { return; }
            
            if(!GetIsInRange())
            {
                GetComponent<Mover>().StartMoveAction(currentTarget.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackAnimation();
            }
        }
        private void AttackAnimation()
        {
            GetComponent<Animator>().SetTrigger("attack");
        }
        public void Attack(CombatTarget target)
        {
            currentTarget = target;
            target.GetHit();
        }
        public void Cancel()
        {
            currentTarget = null;
        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, currentTarget.transform.position) < weaponRange;
        }
    }
}