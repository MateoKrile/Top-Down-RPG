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
            controls.Movement.GoTo.performed += context => MoveToCursor();
            controls.Movement.GoTo.performed += context => InteractWithCombat();
        }
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray.origin, ray.direction, out hit, 100);
            if(hasHit)
            {
                Vector3 direction = hit.point;
                GetComponent<Mover>().MoveTo(direction);
            }
        } 
        public void InteractWithCombat()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit[] hits = Physics.RaycastAll(ray, 100);
            foreach( RaycastHit hit in hits)
            {
                var enemy = hit.transform.GetComponent<CombatTarget>();
                if(enemy!=null & myFighter!=null)
                {
                    myFighter.Attack();
                }
            }
        }   
    }
}
