using System;
using System.IO;
using System.Collections.Generic;
namespace neuro
{
	public class NeuroNW
	{
		neuron[][] neuronlist;
		public NeuroNW(int[] network)
		{
			//построение листа нейронов
			neuronlist = new neuron[network.Length][];
			for (int i = 0; i < network.Length; i++)
			{
				neuronlist[i] = new neuron[network[i]];
			}
			for (int i = 0; i < network[0]; i++)
			{
				neuronlist[0][i] = new neuron(network[0]);
			}
			for (int i = 1; i < network.Length;i++)
				for (int k = 0; k < network[i];k++)
				{
					neuronlist[i][k] = new neuron(network[i-1]);
				}

		}


		public static void Main(String[] args)
		{
			
			NeuroNW nw = new NeuroNW(new int[] {2,3,1});
			nw.loadNetwork();
			double[] res=nw.Calculate(new double[] { 1, -1 },nw.neuronlist);
			foreach (double print in res)
			{
				if (Math.Abs(print) > 0)
				{
					Console.WriteLine(print);
				}
			}

		}

		double[] Calculate(double[] input, neuron[][] neurons)
		{
			List<double> inp = new List<double>(input);
			List<double> layer_answer = new List<double>();
			for (int i = 0; i<neurons.GetLength(0); i++)
			{
				for (int n = 0; n < neurons[i].Length;n++)
				{
					layer_answer.Add(neurons[i][n].Answer(inp.ToArray()));
				}
				inp.Clear();
				foreach (double answer in layer_answer)
				{
					inp.Add(answer);
				}
				layer_answer.Clear();
			}
			return inp.ToArray();
		}

		void saveNetwork()
		{
			if (neuronlist != null)
			{
				StreamWriter writer = new StreamWriter("weights.txt");
				for (int i = 0; i < neuronlist.GetLength(0); i++)
				{
					for (int j = 0; j < neuronlist[i].Length; j++)
					{
						foreach (double weight in neuronlist[i][j]._weights)
						{
							writer.Write(weight.ToString()+' ');
						}
						writer.WriteLine();
					}
				}
				writer.Close();
			}
		}
		void loadNetwork()
		{
			if (neuronlist != null)
			{
				StreamReader reader = new StreamReader("weights.txt");
				for (int i = 0; i < neuronlist.GetLength(0); i++)
				{
					for (int j = 0; j < neuronlist[i].Length; j++)
					{
						try
						{
							string[] weights = reader.ReadLine().Split(' ');
							for (int k = 0; k < weights.Length; k++)
							{
								if (weights[k] != "")
								{
									neuronlist[i][j]._weights[k] = double.Parse(weights[k]);
								}
							}
						}
						catch
						{
							Console.Write("exception. Generating random weights");
							reader.Close();
							GenerateWeights();
						}
					}
				}
				reader.Close();

			}
		}
		void GenerateWeights()
		{
			if (neuronlist != null)
			{
				Random rnd = new Random();
				StreamWriter writer = new StreamWriter("weights.txt");
				for (int i = 0; i < neuronlist.GetLength(0); i++)
				{
					for (int j = 0; j < neuronlist[i].Length; j++)
					{
						foreach (double weight in neuronlist[i][j]._weights)
						{
							writer.Write(rnd.NextDouble().ToString() + ' ');
						}
						writer.WriteLine();
					}
				}
				writer.Close();
			}
		}
	}
}
