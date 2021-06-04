using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDist = 5f;
        void Update()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if(player == null) { return; }
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < chaseDist)
            {
                Debug.Log(gameObject.name + "Should attack");
            }
        }
    }
}