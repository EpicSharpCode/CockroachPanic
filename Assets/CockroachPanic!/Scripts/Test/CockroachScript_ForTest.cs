using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace CockroachPanic.Test
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
    public class CockroachScript_ForTest : CockroachScript
    {
        public override void OnEnable()
        {
            if (navMeshAgent == null) navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}
