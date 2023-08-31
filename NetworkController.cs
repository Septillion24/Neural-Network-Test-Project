class NetworkController
{
    private static NetworkController instance;

    private List<List<Network>> generations = new() { };
    private List<Network> currentGeneration = new() { };
    private List<Neuron> expectedOutputLayer = new() { };
    private double currentMutationRate = 2.0;

    private NetworkController()
    {

    }

    public static NetworkController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NetworkController();
            }
            return instance;
        }
    }

    public void createNewGeneration(int populationSize)
    {

        Network successor = pickBestGenerationMember(currentGeneration);
        // currentMutationRate /= 3;
        List<Network> nextGeneration = new() { };
        for (int i = 0; i < populationSize; i++)
        {
            nextGeneration.Add(successor.createNewDerivedNetwork(currentMutationRate));
        }

        
        currentGeneration = nextGeneration;
        generations.Add(nextGeneration);

    }


    public void createStartGeneration(int populationSize, List<Neuron> input, List<Neuron> expectedOutput)
    {
        this.expectedOutputLayer = expectedOutput;
        List<Network> generation = new() { };
        for (int i = 0; i < populationSize; i++)
        {
            generation.Add(new Network(input));
        }
        generations.Add(generation);
        currentGeneration = generation;

    }


    public Network pickBestGenerationMember(List<Network> generation)
    {
        (Network network, double score) best = new();
        

        foreach (Network network in generation)
        {
            if (best.network == null)
            {
                best.network = network;
                best.score = NetworkEvaluiator.evaluateNetwork(network, expectedOutputLayer);
            }
            if (NetworkEvaluiator.evaluateNetwork(network, expectedOutputLayer) is var score && score > best.score)
            {
                best.network = network;
                best.score = score;
            }
        }
        foreach(Network neuron in currentGeneration)
        {
            neuron.displayOutput();
        }
        Console.WriteLine("Picked best member with output:");
        best.network.displayOutput();

        return best.network;
    }
    public Network pickBestGenerationMember()
    {
        List<Network> generation = currentGeneration;
        return pickBestGenerationMember(generation);
    }

}