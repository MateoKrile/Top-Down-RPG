using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
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
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
            myNavMesh.isStopped = false;
            myNavMesh.destination = destination;
        }
        public void Cancel()
        {
            myNavMesh.isStopped = true;
        }
        private void UpdateAnimation()
        {
            Vector3 velocity = myNavMesh.velocity;
            Vector3 localVel = transform.InverseTransformVector(velocity);
            myAnimator.SetFloat("forwardSpeed", localVel.z);
        }
    }
}
