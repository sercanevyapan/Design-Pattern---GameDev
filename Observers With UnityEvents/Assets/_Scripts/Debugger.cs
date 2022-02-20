using System.Diagnostics;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Debugger : MonoBehaviour
{
    IEnumerator  Start() {
        Health health = GetComponent<Health>();
        Level level = GetComponent<Level>();
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log($"Exp: {level.GetExperience()}, Level: {level.GetLevel()}, Health: {health.GetHealth()}");
        }
    }
}
