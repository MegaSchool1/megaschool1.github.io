﻿namespace MegaSchool1.Model.Game;

public class DayStats
{
    public DayStats(DayOfYear day)
    {
        this.Day = day;
    }

    public DayOfYear Day { get; }
    public (decimal Gross, decimal Net) Income { get; set; }
    public bool CompletedActiveIncomeWork { get; set; }
    public bool ProcessedExpenses { get; set; }
    public (decimal Gross, decimal Net, Income Income)[] Incomes { get; set; } = [];
    public List<(string Name, decimal Amount)> Thefts { get; } = [];

}