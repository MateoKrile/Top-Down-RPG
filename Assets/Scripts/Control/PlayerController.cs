using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Fighter myFighter;
        PlayerControls controls;
        private void Start()
        {
            myFighter = GetComponent<Fighter>();
            controls = new PlayerControls();
            controls.Movement.Enable();
            controls.Movement.GoTo.performed += context => Interact();
        }
        private void Interact()
        {
            if(InteractWithCombat()) { return; }
            if(InteractWithMovement()) { return; }
        }
        private bool InteractWithMovement()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray.origin, ray.direction, out hit, 100);
            if(hasHit)
            {
                if(Mouse.current.IsPressed())
                {
                    Vector3 destiantion = hit.point;
                    GetComponent<Mover>().StartMoveAction(destiantion);
                }
                return true;
            }
            return false;
        } 
        public bool InteractWithCombat()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit[] hits = Physics.RaycastAll(ray, 100);
            foreach( RaycastHit hit in hits)
            {
                var enemy = hit.transform.GetComponent<CombatTarget>();
                if(!enemy) { continue; }
                if(Mouse.current.IsPressed())
                {
                    myFighter.Attack(enemy);
                }
                return true;
            }
            return false;
        }   
    }
}
