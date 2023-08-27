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
        activation = calculateActivation(previousNeuronsWithWeight);
    }
    public Neuron()
    {
        activation = calculateActivation(previousNeuronsWithWeight);
    }

    private double getRandomDouble()
    {
        Random rand = new Random();
        double minValue = -2.0;
        double maxValue = 2.0;
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

    public double getActivationNumber()
    {
        return activation;
    }

    private double calculateActivation(Dictionary<Neuron, double> previousNeuronsWithWeight)
    {
        double sum = 0;
        foreach (var kvp in previousNeuronsWithWeight)
        {

            sum += kvp.Key.getActivationNumber() * kvp.Value;
        }
        sum += bias;
        sum = LogSigmoid(sum);
        return sum;
    }

    public double LogSigmoid(double x)
    {
        if (x < -45.0) return 0.0;
        else if (x > 45.0) return 1.0;
        else return 1.0 / (1.0 + Math.Exp(-x));
    }
}