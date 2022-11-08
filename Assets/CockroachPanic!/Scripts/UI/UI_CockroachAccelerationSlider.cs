using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_CockroachAccelerationSlider : UI_CockroachPanicSlider_Main
    {
        public override void Start()
        {
            base.Start();
            var borders = GameManagerScript.GetCockroachAccelerationBorders();
            SetupSlider(borders.min, borders.max);
        }

        public override void OnValueChanged()
        {
            base.OnValueChanged();
            GameManagerScript.SetCockroachAcceleration(slider.value);
        }
    }
}
