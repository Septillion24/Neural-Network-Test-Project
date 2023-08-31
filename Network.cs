class Network
{
    List<Neuron> inputLayer = new() { };
    List<List<Neuron>> hiddenLayers = new() { };
    List<Neuron> outputLayer = new() { };

    public Network(List<Neuron> input)
    {
        createNetwork(input, 2, 12, 1);
    }
    public Network(List<Neuron> inputLayer, List<List<Neuron>> hiddenLayers, List<Neuron> outputLayer)
    {
        this.inputLayer = inputLayer;
        this.hiddenLayers = hiddenLayers;
        this.outputLayer = outputLayer;
    }


    public List<Neuron> getOutputLayer() => outputLayer;
    public List<Neuron> getInputLayer() => inputLayer;


    public void createNetwork(List<Neuron> inputLayer, int hiddenLayers, int neuronsInHiddenLayers, int outputNeurons)
    {
        this.inputLayer = inputLayer;
        this.hiddenLayers = createHiddenLayers(inputLayer, hiddenLayers, neuronsInHiddenLayers, outputNeurons);
        this.outputLayer = new() { new Neuron(this.hiddenLayers.Last()) };
    }

    public void randomizeWeightsAndBiasWithMaxChange(double maxChange)
    {
        foreach (List<Neuron> layer in hiddenLayers)
        {
            foreach (Neuron neuron in layer)
            {
                neuron.randomizeWeightsAndBiasWithMaxChange(maxChange);
            }
        }
    }


    public Network createNewDerivedNetwork(double maxChange)
    {
        List<Neuron> inputLayer = new();
        List<List<Neuron>> hiddenLayers = new();
        List<Neuron> outputLayer = new();
        foreach (Neuron neuron in this.inputLayer)
        {
            inputLayer.Add(neuron.createNewDerivedNeuron(maxChange));
        }
        List<Neuron> currentHiddenLayer = new() { };
        foreach (List<Neuron> layer in this.hiddenLayers)
        {
            foreach (Neuron neuron in layer)
            {
                currentHiddenLayer.Add(neuron.createNewDerivedNeuron(maxChange));
            }
            hiddenLayers.Add(currentHiddenLayer);
            currentHiddenLayer = new() { };
        }
        foreach (Neuron neuron in this.outputLayer)
        {
            outputLayer.Add(neuron.createNewDerivedNeuron(maxChange));
        }
        return new Network(inputLayer, hiddenLayers, outputLayer);
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
    public void displayOutput()
    {
        Console.WriteLine("Output Layer:");
        foreach (var neuron in outputLayer)
        {
            Console.WriteLine($"Activation: {neuron.getActivationNumber()}");
        }
    }

}