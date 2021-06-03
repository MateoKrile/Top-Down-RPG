using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
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
                GetComponent<Mover>().Stop();
            }
        }
        public void Attack(CombatTarget target)
        {
            currentTarget = target;
            Debug.Log("Die you f*&$ing peasnt");
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