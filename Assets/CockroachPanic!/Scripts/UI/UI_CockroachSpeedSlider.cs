using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CockroachPanic.UI
{
    public class UI_CockroachSpeedSlider : UI_CockroachPanicSlider_Main
    {
        public override void Start()
        {
            base.Start();
            var borders = GameManagerScript.GetCockroachSpeedBorders();
            SetupSlider(borders.min, borders.max);
        }

        public override void OnValueChanged()
        {
            base.OnValueChanged();
            GameManagerScript.SetCockroachSpeed(slider.value);
        }
    }
}
