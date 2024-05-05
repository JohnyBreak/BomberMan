using UnityEngine;
using Zenject;
public class GameObjectFactory
{
    private readonly DiContainer _container;
    public GameObjectFactory(DiContainer container)
    {
        _container = container;
    }

    public T InstantiatePrefab<T>(T prefabComponent) where T : Component
    {
        return _container.InstantiatePrefab(prefabComponent).GetComponent<T>();
    }

    public T InstantiatePrefab<T>(T prefabComponent, Transform parent) where T : Component
    {
        return _container.InstantiatePrefab(prefabComponent, parent).GetComponent<T>();
    }

    public T InstantiatePrefab<T>(
        T prefabComponent, 
        Vector3 position, 
        Quaternion quaternion, 
        Transform parent) 
        where T : Component
    {
        return _container.InstantiatePrefab(
            prefabComponent, 
            position,
            quaternion,
            parent).GetComponent<T>();
    }
}
