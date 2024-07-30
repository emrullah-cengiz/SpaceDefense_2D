using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public static class CustomZenjectBindings
{
    public static void BindPoolGroup<TItemContract, TPool, TPoolGroup, TEnum>(this DiContainer container,
                                                                              string resourceFolder,
                                                                              Transform poolsParent = null,
                                                                              Action<MemoryPoolInitialSizeMaxSizeBinder<TItemContract>> configurePoolGroup = null)
        where TItemContract : UnityEngine.Object
        where TPool : IMemoryPool
        where TPoolGroup : IMemoryPoolGroup
        where TEnum : Enum
    {
        // Bind pool per enum type wth given ID
        foreach (TEnum typeEnum in Enum.GetValues(typeof(TEnum)))
        {
            var binder = container.BindMemoryPool<TItemContract, TPool>()
                                     .WithId(typeEnum);

            configurePoolGroup?.Invoke(binder);

            var binder2 = binder.FromComponentInNewPrefabResource($"{resourceFolder}/{typeEnum}");

            if (poolsParent != null)
                binder2.UnderTransform(poolsParent);
            else
                binder2.UnderTransformGroup($"{nameof(TItemContract)}s");
        }

        container.Bind<TPoolGroup>().AsSingle();
    }
}
