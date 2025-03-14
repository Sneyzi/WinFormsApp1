namespace WinFormsApp1
{
    // Пункт 1: Інтерфейс
    public interface ISendable
    {
        decimal CalculateCost(); // Інтерфейсна властивість
        int this[int index] { get; set; } // Інтерфейсний індексатор
    }
}