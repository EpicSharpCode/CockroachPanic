using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic {
    public class FingerScript : MonoBehaviour
    {
        [SerializeField]
        FingerLight fingerLight;

        private void Update()
        {
            if (!GameManagerScript.fingerActiveState) { fingerLight.LightOnPoint(false, Vector3.zero); return; }

            if (Input.GetMouseButton(0))
            {
                fingerLight.Setup(GameManagerScript.fingerAvoidRadius);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                Physics.Raycast(ray, out raycastHit);

                fingerLight.LightOnPoint(true, raycastHit.point);

                PanicSphere(raycastHit.point);
            } else
            {
                fingerLight.LightOnPoint(false, Vector3.zero);
            }
        }

        private void PanicSphere(Vector3 center)
        {
            var colliders = Physics.OverlapSphere(center, GameManagerScript.fingerAvoidRadius);
            foreach (var collider in colliders)
            {
                var cockroachScript = collider.GetComponent<IAnimal>();
                if(cockroachScript == null) { continue; }
                cockroachScript.Panic(center);
            }
        }
    }

    [System.Serializable]
    public class FingerLight
    {
        [SerializeField] Light fingerSpotLight;

        float defaultInnerSpotAngle = -1;
        float defaultSpotAngle = -1;

        public void Setup(float radiusModifier)
        {
            if (defaultInnerSpotAngle == -1 || defaultSpotAngle == -1)
            {
                defaultInnerSpotAngle = fingerSpotLight.innerSpotAngle;
                defaultSpotAngle = fingerSpotLight.spotAngle;
            }

            fingerSpotLight.spotAngle = defaultSpotAngle * radiusModifier;
            fingerSpotLight.innerSpotAngle = defaultInnerSpotAngle * radiusModifier;
        }

        public void LightOnPoint(bool state, Vector3 point)
        {
            fingerSpotLight.gameObject.SetActive(state);
            fingerSpotLight.transform.LookAt(point);
        }
    }
}
