namespace TP03;

public class InputHandler
{
    private double[] args;

    public InputHandler(double[] args)
    {
        this.args = args;
    }

    public double getMontant()
    {
        return this.args[0];
    }
}
