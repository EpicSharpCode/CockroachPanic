using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_CockroachAvoidSlider : UI_CockroachPanicSlider_Main
    {
        public override void Start()
        {
            base.Start();
            var borders = GameManagerScript.GetFingerAvoidRadiusBorders();
            SetupSlider(borders.min, borders.max);
        }

        public override void OnValueChanged()
        {
            base.OnValueChanged();
            GameManagerScript.SetFingerAvoidRadius(slider.value);
        }
    }
}
