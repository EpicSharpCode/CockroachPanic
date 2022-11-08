using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace CockroachPanic 
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
    public class CockroachScript : MonoBehaviour, IAnimal
    {
        [SerializeField] string cockroachName = "Cockroach";
        [SerializeField] float cockroachSpeed = 5;
        [SerializeField] float accelerationModifier = 2;
        [SerializeField] float lerpSpeed = 5;

        public bool activeState { get; private set; }

        protected NavMeshAgent navMeshAgent = null;

        Coroutine panicCoroutine;

        float speed = 0;
        bool accelerationState = false;

        public virtual void OnEnable() 
        { 
            if (navMeshAgent == null) navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.SetDestination(GameManagerScript.GetFinish().position);
            SetActive(true);
            cockroachSpeed = GameManagerScript.cockroachSpeed;
            accelerationModifier = GameManagerScript.cockroachAcceleration;
        }

        private void Update()
        {
            SpeedLerpSet();
        }

        private void SpeedLerpSet()
        {
            speed = Mathf.Lerp(speed, cockroachSpeed + ((accelerationState ? 1 : 0) * (accelerationModifier * cockroachSpeed)),
                Time.deltaTime * lerpSpeed);
            navMeshAgent.speed = speed;
        }

        public void SetActive(bool state)
        {
            activeState = state;
            navMeshAgent.isStopped = !activeState;
        }

        public void Panic(Vector3 fingerPoint)
        {
            accelerationState = true;
            if(panicCoroutine != null) StopCoroutine(panicCoroutine);
            panicCoroutine = StartCoroutine(Cooldown());

            navMeshAgent.SetDestination(transform.position + (transform.position - fingerPoint).normalized * 10);
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(GameManagerScript.GetCockroachPanicTime()); // cooldown time
            accelerationState = false;
            navMeshAgent.SetDestination(GameManagerScript.GetFinish().position);
        }

        public GameObject GetGameObject() => gameObject;
    }
}
