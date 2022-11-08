using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic
{
    public interface IAnimal
    {
        void SetActive(bool state);
        void Panic(Vector3 fingerPoint);
        GameObject GetGameObject();
    }
}
