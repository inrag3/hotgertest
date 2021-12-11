
public interface IComplexity
{
    public Complexity Complexity { get; }
}


//Если что убрать потом.
public enum Complexity
{
    Easy,
    Medium,
    Hard,
}

public interface IBallSettings
{
    public float BallSpeed { get; }
}