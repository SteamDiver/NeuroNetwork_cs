using System;
namespace neuro
{
	public class neuron
	{
		double _inputs;
		public double[] _weights;
		public neuron(int inputs)
		{
				_inputs = inputs;
				_weights = new double[inputs];
		}
		private double summator(double[] signal)
		{
			double sum = 0;
			for (int i = 0; i < _inputs; i++)
			{
				sum += signal[i] * _weights[i];
			}
			return sum;
		}
		public double Answer(double[] signal)
		{
			return 1/(1+Math.Exp(-summator(signal)));

		}
	}
}
