﻿using AdventOfCode2024.Solvers;

namespace AdventOfCode2024;

class Program
{

    static int day = 7;

    static void Main(string[] args)
    {
        var solver = SolverFactory.GetSolver(day);
        solver.Solve();
        
    }
}