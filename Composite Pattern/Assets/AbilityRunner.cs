using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{

    [SerializeField]
    IAbility currentAbility =
        new SequenceComposite(

            new IAbility[]
            {
                new HealAbility(),
                new RageAbility(),
                new DelayedDecorator(
                    new RageAbility()

                )
            }

       );

    public void UseAbility()
    {

        currentAbility.Use(gameObject);

    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IAbility
{
    private IAbility[] children;

    public SequenceComposite(IAbility[] children)
    {
        this.children = children;
    }

    public void Use(GameObject currentGameObject)
    {
        foreach (var child in children)
        {
            child.Use(currentGameObject);
        }
    }
}

public abstract class BaseAbilitySO : ScriptableObject, IAbility
{
    public abstract void Use(GameObject currentGameObject);
}

public class DelayedDecorator : IAbility
{
    private IAbility wrappedAbility;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        // TODO some delaying functionality
        wrappedAbility.Use(currentGameObject);
    }
}


public class RageAbility : IAbility
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

public class HealAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}
