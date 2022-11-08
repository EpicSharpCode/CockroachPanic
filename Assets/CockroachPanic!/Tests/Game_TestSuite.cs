using System.Collections;
using System.Collections.Generic;
using CockroachPanic.UI;
using CockroachPanic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class Game_TestSuite
{

    [UnityTest]
    public IEnumerator CameraMotionIsRotatingCameraObject()
    {
        GameObject obj = new GameObject("testObj");
        obj.AddComponent<Camera>();
        obj.AddComponent<CameraMotion>();
        var eulerAngles1 = obj.transform.eulerAngles;
        yield return new WaitForSeconds(0.1f);
        var eulerAngles2 = obj.transform.eulerAngles;
        Assert.AreNotEqual(eulerAngles1, eulerAngles2);
        Object.Destroy(obj);
    }

    [UnityTest]
    public IEnumerator CheckFinishedStateWhenEnoughCountOfAnimalsInFinishZone()
    {
        GameObject obj = new GameObject("testObj");
        obj.transform.position = new Vector3(-100,-100,-100);
        var gameManager = obj.AddComponent<GameManagerScript>();
        obj.AddComponent<FinishZoneScript>();
        var collider = obj.AddComponent<BoxCollider>();
        collider.size = new Vector3(100,100,100);
        collider.center = collider.size / 2;
        collider.isTrigger = true;

        GameManagerScript.SetFinish(obj.transform);
        GameManagerScript.SetCockroachCount(GameManagerScript.GetCockroachMaxCount());
        GameObject[] cockroaches = new GameObject[GameManagerScript.cockroachCount];
        for(int i = 0; i < GameManagerScript.cockroachCount; i++)
        {
            GameObject go = new GameObject("Cockroach " + i);
            go.transform.position = Vector3.zero;
            go.AddComponent<BoxCollider>();
            go.AddComponent<CockroachPanic.Test.CockroachScript_ForTest>();
            go.transform.Translate(obj.transform.position);
            cockroaches[i] = go;
        }
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(true, GameManagerScript.gameFinished);

        Object.Destroy(obj);
        foreach(GameObject go in cockroaches) { Object.Destroy(go); }
    }
}
