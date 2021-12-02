namespace AdventOfCode2021
{
    internal interface IDayCommand
    {
        Task ExecutePart1Async(CancellationToken cancellationToken);
        Task ExecutePart2Async(CancellationToken cancellationToken);
    }
}
