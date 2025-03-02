﻿namespace IdealWeightCalculator
{
    public class WeightRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> weights;
        public WeightRepository()
        {
            weights = new List<WeightCalculator>()
            {
                new WeightCalculator {Height=175,Sex='f'}, /*62.5*/
				new WeightCalculator {Height=167,Sex='m'}, /*62.75*/
				new WeightCalculator {Height=182,Sex='m'}, /*74*/
			};
        }

        public IEnumerable<WeightCalculator> GetWeights()
        {
            return weights;
        }
    }
}
