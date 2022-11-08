using System.Collections;
using System.Collections.Generic;
using CockroachPanic.UI;
using CockroachPanic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class UI_TestSuite
{
    [UnityTest]
    public IEnumerator CockroachInputFieldCantEnterMoreCockroachesThanMaxCount()
    {
        GameObject obj = new GameObject("countInputObj");
        var countInput = obj.AddComponent<UI_CockroachCountInput>();
        var inputField = countInput.GetComponent<TMP_InputField>();
        obj.AddComponent<GameManagerScript>();
        int num = GameManagerScript.GetCockroachMaxCount() + 1;
        inputField.text = num.ToString();
        yield return new WaitForSeconds(0.1f);
        Assert.AreNotEqual(inputField.text, num.ToString());
        Object.Destroy(obj);
    }
    [UnityTest]
    public IEnumerator CockroachInputFieldCantHandleMoreThanOneDigit()
    {
        GameObject obj = new GameObject("countInputObj");
        var countInput = obj.AddComponent<UI_CockroachCountInput>();
        var inputField = countInput.GetComponent<TMP_InputField>();
        obj.AddComponent<GameManagerScript>();
        int num = 11;
        inputField.text = num.ToString();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(inputField.text, GameManagerScript.GetCockroachMaxCount().ToString());
        Object.Destroy(obj);
    }

    [UnityTest]
    public IEnumerator GameLogoIsRotatingByRotateScript()
    {
        GameObject obj = new GameObject("logo");
        obj.AddComponent<Image>();
        obj.AddComponent<UI_LogoMotion>();
        var eulerAngles1 = obj.transform.eulerAngles;
        yield return new WaitForSeconds(0.1f);
        var eulerAngles2 = obj.transform.eulerAngles;
        Assert.AreNotEqual(eulerAngles1, eulerAngles2);
        Object.Destroy(obj);
    }
}
