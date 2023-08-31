class NetworkController
{
    private static NetworkController instance;

    private static List<List<Network>> generations = new() { };
    private static List<Network> currentGeneration = new() { };

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
        if (!generations.Any())
        {

        }
        else
        {

        }

    }

    public void createStartGeneration(int populationSize, List<Neuron> input)
    {
        List<Network> generation = new() { };
        for (int i = 0; i < populationSize; i++)
        {
            generation.Add(new Network(input));
        }
        generations.Add(generation);
    }


    public Network pickBestGenerationMember(List<Network> generation, List<Neuron> expectedOutputLayer)
    {
        (Network network, double score) best = new();

        foreach (Network network in generation)
        {
            if (NetworkEvaluiator.evaluateNetwork(network, expectedOutputLayer) is var score && score > best.score)
            {
                best.network = network;
                best.score = score;
            }
        }

        return best.network;
    }
    public Network pickBestGenerationMember(List<Neuron> expectedOutputLayer)
    {
        List<Network> generation = currentGeneration;
        return pickBestGenerationMember(generation, expectedOutputLayer);
    }

}