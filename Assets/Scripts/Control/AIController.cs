using UnityEngine;
using RPG.Combat;
using RPG.Movement;
using RPG.Core;


namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDist = 5f;
        [SerializeField] float suspicionTime = 5f;
        [SerializeField] PatrolPath myPath;
        [SerializeField] float waypointDwelling = 2f;
        float timeSincePlayerSeen = Mathf.Infinity;
        float timeSinceWaypoint = Mathf.Infinity;
        GameObject player;
        Fighter myFighter;   
        Mover myMover;
        Vector3 guardPosition; 
        int currentIndex = 1;
        float waypointTolerance = 2f;    
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            myFighter = GetComponent<Fighter>();
            myMover = GetComponent<Mover>();
            guardPosition = transform.position;
        }
        void Update()
        {   
            if(player == null) { return; }
            if(IsPlayerInRange() && myFighter.CanAttack(player))
            {   
                AttackBehaviour();
            }
            else if(timeSincePlayerSeen < suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PartolBehaviour();
            }
            UpdateTimers();
        }
        bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.transform.position) < chaseDist;
        }
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDist);
        }
        void AttackBehaviour()
        {
            timeSincePlayerSeen = 0f;
            myFighter.Attack(player);
        }
        void PartolBehaviour()
        {
            Vector3 nextPosition = guardPosition;
            if(myPath != null)
            {
                if(AtWaypoint())
                {
                    timeSinceWaypoint = 0f;
                    NextWaypoint();
                }
                nextPosition = GetWaypoint();
            }
            if(timeSinceWaypoint > waypointDwelling)
            {
                myMover.StartMoveAction(nextPosition);
            }
        }
        void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
        bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }
        Vector3 GetWaypoint()
        {
            return myPath.GetWaypoint(currentIndex);
        }
        void NextWaypoint()
        {
            currentIndex = myPath.GetNextWaypoint(currentIndex);
        }
        void UpdateTimers()
        {
            timeSincePlayerSeen += Time.deltaTime;
            timeSinceWaypoint += Time.deltaTime;
        }
    }
}