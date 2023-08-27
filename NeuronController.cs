class NeuronController
{
    private static NeuronController instance;

    private NeuronController()
    {
        
    }

    public static NeuronController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NeuronController();
            }
            return instance;
        }
    }
}