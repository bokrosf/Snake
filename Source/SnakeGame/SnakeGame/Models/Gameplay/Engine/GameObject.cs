using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.Models.Gameplay.Engine;

/// <summary>
/// Represents an object that takes part in the gameplay.
/// </summary>
public class GameObject : IUpdatable
{
    private List<GameObject> children;
    private List<Component> components;

    /// <summary>
    /// The parent of the <see cref="GameObject"/>.
    /// </summary>
    public GameObject? Parent { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameObject"/> class.
    /// </summary>
    public GameObject()
    {
        children = new List<GameObject>();
        components = new List<Component>();
    }

    /// <summary>
    /// Sets the new parent of the current instance and detaches it from the current parent.
    /// </summary>
    /// <param name="parent">New parent.</param>
    /// <exception cref="ArgumentException">New parent is the same as the current instance.</exception>
    public void SetParent(GameObject? parent)
    {
        if (parent == this)
        {
            throw new ArgumentException("Current instance can not be it's own parent.", nameof(parent));
        }
        
        if (Parent is not null)
        {
            Parent.children.Remove(this);
        }

        Parent = parent;

        if (Parent is not null)
        {
            Parent.children.Add(this);
        }
    }

    /// <summary>
    /// Removes all children from the hierarchy by preserving each child's own hierarchy, and returns the removed children.
    /// </summary>
    public IEnumerable<GameObject> ClearChildren()
    {
        foreach (var c in children)
        {
            c.SetParent(null);
            yield return c;
        }
    }

    /// <summary>
    /// Detaches from the parent and recursively removes all children and components.
    /// </summary>
    public void Clear()
    {
        Queue<GameObject> objectsToRemove = new Queue<GameObject>(children);
        objectsToRemove.Enqueue(this);

        while (objectsToRemove.Any())
        {
            GameObject toRemove = objectsToRemove.Dequeue();
            toRemove.ClearComponents();
            toRemove.children.ForEach(c => objectsToRemove.Enqueue(c));
            toRemove.SetParent(null);
        }        
    }

    /// <summary>
    /// Gets the <see cref="Component"/> that matches the specified type, otherwise throws <see cref="ComponentNotFoundException"/>. 
    /// If more components matches the specified type it returns the first match, and the search order is undefined. 
    /// If more instance of the specified type can match, then calling the <see cref="GetAllComponents"/> method, and identifying the wanted instance is the recommended way.
    /// </summary>
    /// <typeparam name="T">Functionality.</typeparam>
    /// <exception cref="ComponentNotFoundException">No <see cref="Component"/> matches the specified type.</exception>
    public T GetRequiredComponent<T>() where T : notnull, Component
    {
        return GetComponent<T>() ?? throw new ComponentNotFoundException(typeof(T));
    }

    /// <summary>
    /// Gets the <see cref="Component"/> that matches the specified type, otherwise returns <see langword="null"/>. 
    /// If more components matches the specified type it returns the first match, and the search order is undefined. 
    /// If more instance of the specified type can match, then calling the <see cref="GetAllComponents"/> method, and identifying the wanted instance is the recommended way.
    /// </summary>
    /// <typeparam name="T">Functionality.</typeparam>
    public T? GetComponent<T>() where T : notnull, Component
    {
        return components.FirstOrDefault(c => c is T) as T;
    }

    /// <summary>
    /// Gets all <see cref="Component"/>s that matches the specified type.
    /// </summary>
    /// <typeparam name="T">Functionality.</typeparam>
    public IReadOnlyList<T> GetAllComponents<T>() where T : notnull, Component
    {
        return components.Where(c => c is T).Cast<T>().ToList().AsReadOnly();
    }

    /// <summary>
    /// Adds the specified <see cref="Component"/> to extend it's functionality.
    /// </summary>
    /// <param name="component">The functionality to add.</param>
    public void AddComponent(Component component)
    {
        component.Attach(this);
        components.Add(component);
    }

    /// <summary>
    /// Adds a new instance of <typeparamref name="T"/> to extend functionality, and returns the created instance.
    /// </summary>
    /// <typeparam name="T">Functionality to add.</typeparam>
    public T AddComponent<T>() where T : Component, new()
    {
        T component = new T();
        AddComponent(component);

        return component;
    }

    /// <summary>
    /// Removes the specified <see cref="Component"/> to reduce functionality.
    /// </summary>
    /// <param name="component">Functionality to remove.</param>
    public void RemoveComponent(Component component) => components.Remove(component);

    /// <summary>
    /// Removes all <see cref="Component"/>s that matches the specified type to reduce functionality.
    /// </summary>
    /// <typeparam name="T">Funcionality to remove.</typeparam>
    public void RemoveAllComponentsOfType<T>() where T : Component
    {
        for (int i = components.Count - 1; i >= 0; i--)
        {
            if (components[i] is T toRemove)
            {
                toRemove.Detach();
                components.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Removes all <see cref="Component"/>s to reduce functionality.
    /// </summary>
    public void ClearComponents() => RemoveAllComponentsOfType<Component>();

    public void Update()
    {
        foreach (var child in children)
        {
            child.Update();
            child.UpdateComponents();
        }

        UpdateComponents();
    }

    private void UpdateComponents()
    {
        foreach (var behaviour in components.Where(c => c is Behaviour).Cast<Behaviour>())
        {
            behaviour.Update();
        }
    }
}
