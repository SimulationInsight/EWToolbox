namespace SimulationInsight.MathLibrary;

public record AttitudeAngles
{
    public double HeadingAngleDeg { get; init; }

    public double PitchAngleDeg { get; init; }

    public double BankAngleDeg { get; init; }

    public AttitudeAngles(double headingAngleDeg, double pitchAngleDeg, double bankAngleDeg)
    {
        HeadingAngleDeg = headingAngleDeg;
        PitchAngleDeg = pitchAngleDeg;
        BankAngleDeg = bankAngleDeg;
    }
}