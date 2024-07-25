public abstract class EffectBase : IEffect
{
    public IEffectDefinition Data { get; set; }

    protected EffectBase(IEffectDefinition effectDefinition)
    {
        Data = effectDefinition;
    }

    public virtual void Initialize()
    {
    }

    public abstract void Execute();

}
