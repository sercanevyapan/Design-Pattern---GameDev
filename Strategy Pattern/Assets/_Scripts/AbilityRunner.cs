using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{

    [SerializeField] IAbility currentAbility = new RageAbility();

    public void UseAbility()
    {

        currentAbility.Use(gameObject);
      
    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class RageAbility : MonoBehaviour, IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class FireBallAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbility : ScriptableObject, IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}
