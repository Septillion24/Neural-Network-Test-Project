class InputNeuron : Neuron
{
    private double activation;
    List<Neuron> previousNeurons = new() { };
    Dictionary<Neuron, double> previousNeuronsWithWeight = new() { };

    public InputNeuron(double activation)
    {
        this.activation = activation;
    }

    public double getActivation()
    {
        return activation;
    }
    

}