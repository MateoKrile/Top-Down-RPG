using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent myNavMesh;
        Animator myAnimator;
        private void Start()
        {
            myNavMesh = GetComponent<NavMeshAgent>();
            myAnimator = GetComponent<Animator>();
        }
        private void Update()
        {
            UpdateAnimation();
        }
        public void MoveTo(Vector3 destination)
        {
            myNavMesh.destination = destination;
        }
        private void UpdateAnimation()
        {
            Vector3 velocity = myNavMesh.velocity;
            Vector3 localVel = transform.InverseTransformVector(velocity);
            myAnimator.SetFloat("forwardSpeed", localVel.z);
        }
    }
}
