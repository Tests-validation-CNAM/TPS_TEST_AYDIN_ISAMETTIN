namespace TP03;

public class MensualiteTest
{
    [Theory]
    [InlineData(1, 100, 1000)]
    [InlineData(2, 200, 800)]
    [InlineData(3, 300, 500)]
    public void TestMensualite(int numero, double montantPaye, double resteAPayer)
    {
        Mensualite mensualite = new Mensualite(numero, montantPaye, resteAPayer);

        Assert.Equal(numero, mensualite.Numero);
        Assert.Equal(montantPaye, mensualite.MontantPaye);
        Assert.Equal(resteAPayer, mensualite.ResteAPayer);
    }
}
