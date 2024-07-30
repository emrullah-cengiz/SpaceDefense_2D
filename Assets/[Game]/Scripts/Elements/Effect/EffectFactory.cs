using System.Reflection;
using System;
using Zenject;
using System.Collections.Generic;

public class EffectFactory : PlaceholderFactory<IEffectDefinition, EffectHandler, IEffect>
{

}


public class CustomEffectFactory : IFactory<IEffectDefinition, EffectHandler, IEffect>, IValidatable
{
    private readonly DiContainer _container;

    private Dictionary<string, Func<IEffectDefinition, EffectHandler, IEffect>> _effectCreators;

    public CustomEffectFactory(DiContainer container)
    {
        _container = container;

        _effectCreators = new() {
            { nameof(DamageEffectDefinition), GetCreator<DamageEffect>()},
            { nameof(AreaDamageEffectDefinition), GetCreator<AreaDamageEffect>()},
            { nameof(SlowEffectDefinition), GetCreator<SlowEffect>()},
            { nameof(DamageOverTimeEffectDefinition), GetCreator<DamageOverTimeEffect>()},
        };
    }

    public IEffect Create(IEffectDefinition effectDefinition, EffectHandler effectHandler)
    {
        if (_effectCreators.TryGetValue(effectDefinition.GetType().Name, out var creator))
        {
            var effect = creator(effectDefinition, effectHandler);

            return effect;
        }
        else
            throw new Exception($"{effectDefinition.GetType().Name} effect not found!");
    }

    public void Validate()
    {
        foreach (var creator in _effectCreators.Values)
            creator.Invoke(null, null);
    }

    public Func<IEffectDefinition, EffectHandler, IEffect> GetCreator<TEffect>() where TEffect : IEffect
    {
        return (IEffectDefinition effectDefinition, EffectHandler effectHandler) =>
                _container.Instantiate<TEffect>(new object[] { effectDefinition, effectHandler });
    }

}
