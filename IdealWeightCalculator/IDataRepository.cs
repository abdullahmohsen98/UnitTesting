namespace IdealWeightCalculator
{
    public interface IDataRepository
    {
        IEnumerable<WeightCalculator> GetWeights();
    }
}
