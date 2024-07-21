using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public static class CustomZenjectBindings
{
    public static void BindPoolGroup<TItemContract, TPool, TPoolGroup>(this DiContainer container,
                                                                            string resourceFolder,
                                                                            Transform poolsParent,
                                                                            Action<MemoryPoolInitialSizeMaxSizeBinder<TItemContract>> configurePoolGroup = null)
        where TItemContract : UnityEngine.Object
        where TPool : IMemoryPool
        where TPoolGroup : IMemoryPoolGroup
    {
        // Bind pool per enum type wth given ID
        foreach (BuildingType typeEnum in Enum.GetValues(typeof(BuildingType)))
        {
            var binder = container.BindMemoryPool<TItemContract, TPool>()
                                  .WithId(typeEnum);

            configurePoolGroup?.Invoke(binder);

            binder.FromComponentInNewPrefabResource($"{resourceFolder}/{typeEnum}")
                  .UnderTransform(poolsParent);
        }

        container.Bind<TPoolGroup>().AsSingle();
    }
}
