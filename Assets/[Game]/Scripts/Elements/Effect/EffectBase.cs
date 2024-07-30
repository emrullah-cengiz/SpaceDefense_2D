public abstract class EffectBase : IEffect
{
    protected IEffectDefinition Data { get; set; }

    protected readonly EffectHandler _effectHandler;

    protected EffectBase(IEffectDefinition effectDefinition, EffectHandler effectHandler)
    {
        Data = effectDefinition;
        _effectHandler = effectHandler;
    }

    public virtual void Initialize()
    {
    }


    public void Activate(bool s)
    {
        if (s)
            OnEnable();
        else
            OnDisable();
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}
