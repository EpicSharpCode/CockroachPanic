using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CockroachPanic.UI 
{
    [RequireComponent(typeof(TMP_InputField))]
    public class UI_CockroachCountInput : MonoBehaviour
    {
        TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { InputCheck(); });
            InputCheck();
        }

        public void InputCheck()
        {
            if(inputField.text == "") { inputField.text = "1"; }
            int inputDigit = int.Parse(inputField.text);
            if (inputDigit == 0) { inputField.text = "1"; }
            if (inputDigit > GameManagerScript.GetCockroachMaxCount()) 
            { inputField.text = GameManagerScript.GetCockroachMaxCount().ToString(); }

            GameManagerScript.SetCockroachCount(int.Parse(inputField.text));
    }
    }
}
