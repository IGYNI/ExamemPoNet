public class CoffeeOrder
{
    // Свойство для хранения типа кофе
    public string CoffeeType { get; set; }
    
    // Свойство для хранения даты заказа
    public DateTime OrderDate { get; set; }

    // Конструктор по умолчанию
    public CoffeeOrder()
    {
        CoffeeType = "Unknown";
        OrderDate = DateTime.Now; // Устанавливаем текущую дату по умолчанию
    }

    // Конструктор с параметрами
    public CoffeeOrder(string coffeeType, DateTime orderDate)
    {
        CoffeeType = coffeeType;
        OrderDate = orderDate;
    }
    public void PrintOrderInfo()
    {
        Console.WriteLine($"Кофе: {CoffeeType}, Дата заказа: {OrderDate.ToString("dd.MM.yyyy HH:mm")}");
    }

}
