using System.Reflection;
using System;
using Zenject;
using System.Collections.Generic;

public class EffectFactory : PlaceholderFactory<IEffectDefinition, IEffect>
{

}


public class CustomEffectFactory : IFactory<IEffectDefinition, IEffect>, IValidatable
{
    private readonly DiContainer _container;

    private Dictionary<string, Func<IEffectDefinition, IEffect>> _effectCreators;

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

    public IEffect Create(IEffectDefinition effectDefinition)
    {
        if (_effectCreators.TryGetValue(effectDefinition.GetType().Name, out var creator))
        {
            var effect = creator(effectDefinition);

            return effect;
        }
        else
            throw new Exception($"{effectDefinition.GetType().Name} effect not found!");
    }

    public void Validate()
    {
        foreach (var creator in _effectCreators.Values)
            creator.Invoke(null);
    }

    public Func<IEffectDefinition, IEffect> GetCreator<TEffect>() where TEffect : IEffect
    {
        return (IEffectDefinition effectDefinition) =>
                _container.Instantiate<TEffect>(new object[] { effectDefinition });
    }

}
