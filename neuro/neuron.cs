using System;
namespace neuro
{
	public class neuron
	{
		private double _inputs;
		private double[] _weights;
		public neuron(int inputs, double[] weights)
		{
			if (inputs == weights.Length)
			{
				_inputs = inputs;
				_weights = weights;
			}
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
			return 2/1+(Math.Pow(Math.E,-1*summator(signal)))-1;

		}
	}
}
