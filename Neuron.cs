using System.ComponentModel;
using System.Security;

class Neuron
{

    double activation = 0;
    double bias = 0;
    List<Neuron> previousNeurons = new() { };
    Dictionary<Neuron, double> previousNeuronsWithWeight = new Dictionary<Neuron, double>() { };


    public Neuron(List<Neuron> previousNeurons)
    {
        this.previousNeurons = previousNeurons;
        initializeRandomWeightsAndBias(previousNeurons);
        refreshActivation();
    }
    public Neuron()
    {
        refreshActivation();
    }

    private double getRandomDouble(double maxValue = 2, double minValue = -2)
    {
        Random rand = new Random();
        return rand.NextDouble() * (maxValue - minValue) + minValue;
    }

    private void initializeRandomWeightsAndBias(List<Neuron> previousNeurons)
    {
        foreach (Neuron neuron in previousNeurons)
        {
            previousNeuronsWithWeight.Add(neuron, getRandomDouble());
        }
        bias = getRandomDouble();
    }

    public void randomizeWeightsAndBiasWithMaxChange(double maxChange)
    {
        foreach (KeyValuePair<Neuron, double> kvp in previousNeuronsWithWeight)
        {
            // Console.Write("Before: " + kvp.Value);
            previousNeuronsWithWeight[kvp.Key] = kvp.Value + getRandomDouble(maxChange);
            // Console.Write(", After: " + kvp.Value + ", Expected: " + (kvp.Value + getRandomDouble(maxChange)) + "\n");
            refreshActivation();
        }
        bias += getRandomDouble(maxChange);
    }

    public double getActivationNumber()
    {
        return activation;
    }

    private void refreshActivation()
    {
        double sum = 0;
        foreach (var kvp in previousNeuronsWithWeight)
        {

            sum += kvp.Key.getActivationNumber() * kvp.Value;
        }
        sum += bias;
        sum = LogSigmoid(sum);
        activation = sum;
    }

    public double LogSigmoid(double x)
    {
        if (x < -45.0) return 0.0;
        else if (x > 45.0) return 1.0;
        else return 1.0 / (1.0 + Math.Exp(-x));
    }

    public string WeightsToString()
    {
        string weightsString = "";

        foreach (var kvp in previousNeuronsWithWeight)
        {
            weightsString += $"Neuron: {kvp.Key}, Weight: {kvp.Value}\n";
        }

        return weightsString;
    }


}