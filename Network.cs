class Network
{
    List<Neuron> inputLayer = new() { };
    List<List<Neuron>> hiddenLayers = new() { };
    List<Neuron> outputLayer = new() { };

    public Network(List<Neuron> input)
    {
        createNetwork(input, 2, 12, 1);
    }


    public List<Neuron> getOutputLayer() => outputLayer;
    public List<Neuron> getInputLayer() => inputLayer;


    public void createNetwork(List<Neuron> inputLayer, int hiddenLayers, int neuronsInHiddenLayers, int outputNeurons)
    {
        this.inputLayer = inputLayer;
        this.hiddenLayers = createHiddenLayers(inputLayer, hiddenLayers, neuronsInHiddenLayers, outputNeurons);
        this.outputLayer = new() { new Neuron(this.hiddenLayers.Last()) };
    }
    public List<Neuron> createLayer(int neuronsInHiddenLayers, List<Neuron> lastLayer)
    {
        List<Neuron> returnValue = new() { };
        for (int i = 0; i < neuronsInHiddenLayers; i++)
        {
            returnValue.Add(new Neuron(lastLayer));
        }

        return returnValue;
    }
    public List<List<Neuron>> createHiddenLayers(List<Neuron> inputLayer, int numHiddenLayers, int neuronsInHiddenLayers, int outputNeurons)
    {

        List<List<Neuron>> returnValue = new() { };
        List<Neuron> lastLayer = this.inputLayer;

        for (int i = 0; i < numHiddenLayers; i++)
        {
            returnValue.Add(lastLayer = createLayer(neuronsInHiddenLayers, lastLayer));
        }
        return returnValue;
    }

    public void display()
    {
        Console.WriteLine("Input Layer:");
        foreach (var neuron in inputLayer)
        {
            Console.WriteLine($"Activation: {neuron.getActivationNumber()}");
        }

        Console.WriteLine("Hidden Layers:");
        foreach (var layer in hiddenLayers)
        {
            Console.WriteLine("Layer:");
            foreach (var neuron in layer)
            {
                Console.WriteLine($"Activation: {neuron.getActivationNumber()}");
            }
        }

        Console.WriteLine("Output Layer:");
        foreach (var neuron in outputLayer)
        {
            Console.WriteLine($"Activation: {neuron.getActivationNumber()}");
        }
    }

}