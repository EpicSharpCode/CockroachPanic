using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic {
    public class FinishZoneScript : MonoBehaviour
    {
        static FinishZoneScript instance;
        List<IAnimal> animals;

        private void OnEnable()
        {
            instance = this;
            animals = new List<IAnimal>();
        }

        private void Update()
        {
            if(animals.Count == 0) { return; }
            if(animals.Count == GameManagerScript.cockroachCount)
            {
                GameManagerScript.SetGameFinished(true);
                UI.UI_ScreenManager.ShowPopupScreen("GameOverPopup");
                ClearAnimalInList();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var animal = other.gameObject.GetComponent<IAnimal>();
            if (animal != null)
            {
                animals.Add(animal);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var animal = other.gameObject.GetComponent<IAnimal>();
            if(!animals.Contains(animal)) { return; }
            if (animal != null)
            {
                animals.Remove(animal);
            }
        }

        public static void ClearAnimalInList() => instance.animals.Clear();
    }
}
