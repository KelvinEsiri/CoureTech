namespace CoureTech.Application.Interfaces;

/// <summary>
/// Question 1 – calculates a total score from an array of integers.
/// </summary>
public interface IScoreCalculatorService
{
    int Calculate(IEnumerable<int> numbers);
}
