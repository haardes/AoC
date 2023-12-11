namespace _2023.Day09;

public class Day09
{
    private static readonly string[] input = File.ReadAllLines("../../../Day9/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (var history in input)
        {
            var values = history.Split(" ").Select(value => int.Parse(value)).ToList();
            Reducer reducer = new(values);

            while (reducer.CanReduce())
            {
                reducer.Reduce();
            }

            result += reducer.PredictForward();
        }

        Console.WriteLine(result);
        Assert.Equal(2101499000, result);
    }

    private class Reducer
    {
        public readonly List<int> Values;
        private readonly List<List<int>> _history = new();


        public Reducer(List<int> ints)
        {
            Values = ints;
            _history.Add(Values);
        }

        public void Reduce()
        {
            var values = _history.Last();
            var result = new List<int>();

            for (var i = 0; i < values.Count - 1; i++)
            {
                result.Add(values[i + 1] - values[i]);
            }

            _history.Add(result);
        }

        public bool CanReduce()
        {
            return !_history.Last().All(value => value == 0);
        }

        public int PredictForward()
        {
            for (var i = _history.Count - 1; i >= 0; i--)
            {
                if (i == _history.Count - 1) _history[i].Add(0);
                else
                {
                    _history[i].Add(_history[i].Last() + _history[i + 1].Last());
                }
            }

            return _history.First().Last();
        }

        public int PredictBackward()
        {
            for (var i = _history.Count - 1; i >= 0; i--)
            {
                if (i == _history.Count - 1) _history[i].Insert(0, 0);
                else
                {
                    _history[i].Insert(0, _history[i].First() - _history[i + 1].First());
                }
            }

            return _history.First().First();
        }
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        foreach (var history in input)
        {
            var values = history.Split(" ").Select(value => int.Parse(value)).ToList();
            Reducer reducer = new(values);

            while (reducer.CanReduce())
            {
                reducer.Reduce();
            }

            result += reducer.PredictBackward();
        }

        Console.WriteLine(result);
        Assert.Equal(1089, result);
    }
}
