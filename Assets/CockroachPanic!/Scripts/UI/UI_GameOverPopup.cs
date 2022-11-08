using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_GameOverPopup : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManagerScript.PauseGame();
        }

        private void OnDisable()
        {
            GameManagerScript.SetGameFinished(false);
        }
    }
}
