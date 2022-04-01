/// <summary>
/// ECS System
/// </summary>
public abstract class BaseSystem
{
    /// <summary>
    /// Called on game startup
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Called every frame
    /// </summary>
    public virtual void Execute() { }
}