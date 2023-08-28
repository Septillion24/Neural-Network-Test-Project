static class NetworkEvaluiator
{


    public static double evaluateNetwork(Network network, List<Neuron> expectedOutputLayer)
    {
        List<Neuron> recievedOutputLayer = network.getOutputLayer();
        return evaluateNetwork(recievedOutputLayer, expectedOutputLayer);
    }
    public static double evaluateNetwork(List<Neuron> recievedOutputLayer, List<Neuron> expectedOutputLayer)
    {
        if(recievedOutputLayer.Count != expectedOutputLayer.Count)
        {
            throw new InvalidOperationException("Expected output count must be the same as the recieved output count!");
        }
        double cost = 0;
        for(int i = 0; i < recievedOutputLayer.Count; i++)
        {
            cost += Math.Pow((recievedOutputLayer[i].getActivationNumber() - expectedOutputLayer[i].getActivationNumber()), 2);
        }
        return cost;
    }

    

}