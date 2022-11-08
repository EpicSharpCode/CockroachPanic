using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CockroachPanic.UI
{
    [RequireComponent(typeof(Slider))]
    public class UI_CockroachPanicSlider_Main : MonoBehaviour
    {
        public Slider slider { get; private set; }
        [SerializeField] TMP_Text outputValue;
        public virtual void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void SetupSlider(float min, float max)
        {
            slider.minValue = min;
            slider.maxValue = max;
            slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
            slider.value = slider.minValue;
            OnValueChanged();
        }

        public virtual void OnValueChanged()
        {
            outputValue.text = System.Math.Round(slider.value, 1).ToString();
        }
    }
}
