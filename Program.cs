class Program
{
    static void Main(string[] args)
    {

        List<Neuron> input = new()
        {
            new InputNeuron(0),
            new InputNeuron(1),
            new InputNeuron(1),
            new InputNeuron(1),
            new InputNeuron(0),
        };

        Network network = new(input);
        network.displayOutput();
        network.randomizeWeightsAndBiasWithMaxChange(2.0);
        network.displayOutput();
        


        List<Neuron> expected = new()
        {
            new InputNeuron(1)
        };
        Console.WriteLine("Cost: " + NetworkEvaluiator.evaluateNetwork(network, expected));

    }


}

