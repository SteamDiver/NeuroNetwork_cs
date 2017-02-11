using System;
namespace neuro
{
	public class NeuroNW
	{
		neuron[][] neuronlist;
		public NeuroNW(int[] network,int inputs)
		{
			//построение листа нейронов
			neuronlist = new neuron[network.Length][];
			for (int i = 0; i < network.Length; i++)
			{
				neuronlist[i] = new neuron[network[i]];
			}
			for (int i = 0; i < inputs; i++)
			{
				neuronlist[0][i] = new neuron(inputs, new double[] { 1, 1 });
			}
			for (int i = 1; i < network.Length;i++)
				for (int k = 0; k < network[i];k++)
				{
					neuronlist[i][k] = new neuron(network[i-1], new double[] {1,-100 });
				}

		}


		public static void Main(String[] args)
		{
			
			NeuroNW nw = new NeuroNW(new int[] {2,1 },2);
			double[] res=nw.Calculate(new double[] { 1, 0.0000000000001 },nw.neuronlist);
			foreach (double print in res)
			{
				if (Math.Abs(print) > 0)
				{
					Console.WriteLine(print);
				}
			}

		}

		private double[] Calculate(double[] input, neuron[][] neurons)
		{
			double[] res = new double[2];
			double[] layer_answer = new double[2];
			for (int i = 0; i<neurons.GetLength(0); i++)
			{
				for (int n = 0; n < neurons[i].Length;n++)
				{
					layer_answer[n] = neurons[i][n].Answer(input);
				}
				res = (double[])layer_answer.Clone();
				input = (double[])layer_answer.Clone();
				Array.Clear(layer_answer,0,2);
			}
			return res;
		}
	}
}
