using System.Collections.Generic;

public static class HanoiSolver
{
    public static void Solve(int n, int from, int to, int aux, List<Move> moves)
    {
        if (n <= 0) return;

        Solve(n - 1, from, aux, to, moves);
        moves.Add(new Move(from, to));
        Solve(n - 1, aux, to, from, moves);
    }
}
