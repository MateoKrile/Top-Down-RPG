using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        const float waypointRadius = 0.3f;
        private void OnDrawGizmos()
        {
            for(int i=0; i<transform.childCount; i++)
            {
                int next = GetNextWaypoint(i);
                Gizmos.DrawSphere(GetWaypoint(i), waypointRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(next));
            }
        }
        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
        public int GetNextWaypoint(int i)
        {
            if(i+1==transform.childCount)
            {
                return 0;
            }
            return i+1;
        }
    }
}