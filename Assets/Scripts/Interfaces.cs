
public interface IComplexity
{
    public Complexity Complexity { get; }
}

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