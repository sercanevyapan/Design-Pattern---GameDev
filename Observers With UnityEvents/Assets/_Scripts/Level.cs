using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] int pointPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints=0;

    IEnumerator Start() {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    private void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if(GetLevel()>level){
            onLevelUp.Invoke();
        }
    }

    public int GetExperience(){
        return experiencePoints;
    }

    public int GetLevel(){
        return experiencePoints / pointPerLevel;
    }
}
