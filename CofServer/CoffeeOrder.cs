public class CoffeeOrder
{
    // Свойство для хранения типа кофе
    public string CoffeeType { get; set; }
    public string ID { get; set; }
    
    // Свойство для хранения даты заказа
    public DateTime OrderDate { get; set; }

    // Конструктор по умолчанию
    public CoffeeOrder()
    {
        ID = IDCreate();
        CoffeeType = "Unknown";
        OrderDate = DateTime.Now; // Устанавливаем текущую дату по умолчанию
    }

    // Конструктор с параметрами
    public CoffeeOrder(string coffeeType)
    {
        ID = IDCreate();
        CoffeeType = coffeeType;
        OrderDate = DateTime.Now; 
    }
    public void PrintOrderInfo()
    {
        Console.WriteLine($"Кофе: {CoffeeType}, Дата заказа: {OrderDate.ToString("dd.MM.yyyy HH:mm")}, Айди:{ID}");
    }

    private string IDCreate() => $"{new Random().Next(0, 9)}{new Random().Next(0, 9)}{new Random().Next(0, 9)}{new Random().Next(0, 9)}{new Random().Next(0, 9)}{new Random().Next(0, 9)}";

}
