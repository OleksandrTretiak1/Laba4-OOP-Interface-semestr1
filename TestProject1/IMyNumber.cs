namespace InterfaceTask;

// Загальний інтерфейс для чисел
interface IMyNumber<T> where T : IMyNumber<T>
{
    // Метод додавання
    T Add(T b);
    // Метод віднімання
    T Subtract(T b);
    // Метод множення
    T Multiply(T b);
    // Метод ділення
    T Divide(T b);
}