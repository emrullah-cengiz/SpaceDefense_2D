public abstract class EffectBase : IEffect
{
    protected IEffectDefinition Data { get; set; }

    //protected bool IsActive { get; set; }

    protected EffectBase(IEffectDefinition effectDefinition)
    {
        Data = effectDefinition;
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
