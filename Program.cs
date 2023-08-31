class Program
{
    static void Main(string[] args)
    {
        List<Neuron> input = new() 
        {
            new InputNeuron(0),
            new InputNeuron(1)
        };
        List<Neuron> expectedOutput = new()
        {
            new InputNeuron(1)
        };

        NetworkController controller = NetworkController.Instance;

        controller.createStartGeneration(10, input, expectedOutput);


        while(true)
        {

            Console.WriteLine("Press enter to make new generation");
            Console.ReadLine();
            controller.createNewGeneration(10);
        }


    }


}

