using CoureTech.Application.Interfaces;

namespace CoureTech.Application.Services;

public class ScoreCalculatorService : IScoreCalculatorService
{
    public int Calculate(IEnumerable<int> numbers)
    {
        int total = 0;

        foreach (int num in numbers)
        {
            if (num % 2 == 0)
                total += 1;
            else
                total += 3;

            if (num == 8)
                total += 5;
        }

        return total;
    }
}
