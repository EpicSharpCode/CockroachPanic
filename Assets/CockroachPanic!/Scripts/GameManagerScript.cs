using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CockroachPanic
{
    public class GameManagerScript : MonoBehaviour
    {
        static GameManagerScript instance;
        public static bool fingerActiveState { get; private set; }

        [Header("Cockroach Settings")]
        [SerializeField] GameObject cockroachPrefab;
        [SerializeField] GameObject cockroachesContent;
        [SerializeField] int cockroachMaxCount = 6;
        [SerializeField] float cockroachPanicTime = 1;

        [Space(5)]
        [SerializeField] int cockroachMinSpeed = 5;
        [SerializeField] int cockroachMaxSpeed = 10;
        [Space(5)]
        [SerializeField] int cockroachMinAcceleration = 2;
        [SerializeField] int cockroachMaxAcceleration = 5;

        [Header("Finger Settings")]
        [SerializeField] float fingerAvoidRadiusMin = 1;
        [SerializeField] float fingerAvoidRadiusMax = 5;

        [Header("Points Settings")]
        [SerializeField] Transform start;
        [SerializeField] Transform finish;
        [SerializeField] Transform spawnPoints;

        public static int cockroachCount { get; private set; }
        public static float cockroachSpeed { get; private set; }
        public static float cockroachAcceleration { get; private set; }
        public static float fingerAvoidRadius { get; private set; }
        public static bool gameFinished { get; private set; }

        List<IAnimal> animalTribe;

        UnityEvent gameStart;

        private void OnEnable() 
        { 
            instance = this;
            fingerActiveState = false;

            animalTribe = new List<IAnimal>();

            gameStart = new UnityEvent();
            gameStart.AddListener(ClearAnimals);
            gameStart.AddListener(SpawnCockroaches);
        }

        #region GameState Functions
        public static void StartGame()
        {
            instance.gameStart.Invoke();
            fingerActiveState = true;
            FinishZoneScript.ClearAnimalInList();
        }
        public static void PauseGame()
        {
            foreach (var cockroach in instance.animalTribe)
            {
                cockroach.SetActive(false);
            }
            fingerActiveState = false;
        }
        public static void ResumeGame()
        {
            foreach (var cockroach in instance.animalTribe)
            {
                cockroach.SetActive(true);
            }
            fingerActiveState = true;
        }
        public static void StopGame()
        {
            instance.ClearAnimals();
            fingerActiveState = false;
        }
        #endregion

        #region SpawnAnimals Functions
        void SpawnCockroaches()
        {
            if(animalTribe.Count != 0) { return; }
            for (int i = 0; i < cockroachCount; i++)
            {
                var cockroach = Instantiate(cockroachPrefab, cockroachesContent.transform);
                cockroach.transform.position = spawnPoints.GetChild(i).position;
                animalTribe.Add(cockroach.GetComponent<IAnimal>());
            }
        }
        void ClearAnimals()
        {
            foreach(var cockroach in animalTribe)
            {
                Destroy(cockroach.GetGameObject());
            }
            animalTribe.Clear();
        }
        #endregion

        #region Get Functions
        public static Transform GetFinish() => instance.finish;
        public static int GetCockroachMaxCount() => instance.cockroachMaxCount;
        public static float GetCockroachPanicTime() => instance.cockroachPanicTime;
        public static int GetAnimalTribeCount() => instance.animalTribe.Count;
        public static (float min, float max) GetCockroachSpeedBorders()
        {
            return (instance.cockroachMinSpeed, instance.cockroachMaxSpeed);
        }
        public static (float min, float max) GetFingerAvoidRadiusBorders()
        {
            return (instance.fingerAvoidRadiusMin, instance.fingerAvoidRadiusMax);
        }
        public static (float min, float max) GetCockroachAccelerationBorders()
        {
            return (instance.cockroachMinAcceleration, instance.cockroachMaxAcceleration);
        }
        #endregion

        #region Set Functions
        public static void SetFinish(Transform tr) => instance.finish = tr;
        public static void SetGameFinished(bool state) => gameFinished = state;
        public static void SetCockroachCount(int count) => cockroachCount = count;
        public static void SetCockroachSpeed(float speed) => cockroachSpeed = speed;
        public static void SetCockroachAcceleration(float acceleration) => cockroachAcceleration = acceleration;
        public static void SetFingerAvoidRadius(float radius) => fingerAvoidRadius = radius;
        #endregion
    }
}
