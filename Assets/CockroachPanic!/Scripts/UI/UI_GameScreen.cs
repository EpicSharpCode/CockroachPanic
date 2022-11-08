using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_GameScreen : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManagerScript.StartGame();
        }

        private void OnDisable()
        {
            GameManagerScript.StopGame();
        }
    }
}
