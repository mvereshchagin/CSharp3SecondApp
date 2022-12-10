// using app = CSharp3SecondApp; //псевдоним
// using System.IO; // подключение прсотранства имен
using CSharp3SecondApp;
using MyFileAccess = CSharp3SecondApp.FileAccess;

//тип_возращаемого_значение название_функции()
//{ }

//тип_возращаемого_значение название_функции(
//    тип_параметра название_параметра <=Значение по умолчанию>,
//    тип_параметра название_параметра <=Значение по умолчанию>)
//{ }

//void = ничего не возращает функция

//return ... // возврат значения из функции

// не принимает никаких пармаметров, не возвращает никакого значения (можно не использовать return)
// имеет назвение PrintHello
void PrintHello() 
{
    Console.WriteLine("Hello");
}

PrintHello(); // Вызов функции PrintHello

// Определили функцию с названием PrintHello2, ничего не возращает, принимет один параметр типа 
// string с именем name
void PrintHello2(string name)
{
    name = "Petya";
    Console.WriteLine($"Hello, {name}");
}

Console.WriteLine(String.Empty);
Console.WriteLine("===============================");
string myName = "Vasya";
PrintHello2(myName);
Console.WriteLine(myName);

void PrintHello3(ref string name) // ref = параметр передается по ссылке
{
    name = "Petya";
    Console.WriteLine($"Hello, {name}");
}


Console.WriteLine(String.Empty);
Console.WriteLine("===============================");
string myName3 = "Vasya";
PrintHello3(ref myName3); // передаем переменнуб myName3 по ссылке
Console.WriteLine(myName3);

// пример изменения примитивного (по значению) типа данных
int a = 10;
int b = a;
a = 20;
Console.WriteLine($"b = {b}");


// пример изменения ссылочного типа дынных
int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;
arr1[0] = 10;
foreach (var item in arr2)
    Console.Write($"{item}, ");


// Функция, принимающая два параметра
void PrintHelloSaySomething(string name, string message)
{
    Console.WriteLine($"Hello, {name}");
    Console.WriteLine(message);
}

// вызов функции с неименованными параметрами. Порядок важен!
PrintHelloSaySomething("Oleg", "Get out from my App");

// вызов функции с именованными параметрами
PrintHelloSaySomething(name: "Olga", message: "Welcome again");

// вызов функции с именованными параметрами (поменяли порядок)
PrintHelloSaySomething(message: "How are you?", name: "Ivan");

//  = null! подавить предупреждение nullable
void PrintHelloSaySomething2(string name, string message = null!)
{
    Console.WriteLine($"Hello, {name}");
    Console.WriteLine(message);
}

// message может быть null и это нормально
void PrintHelloSaySomething3(string name, string? message = null)
{
    Console.WriteLine($"Hello, {name}");
    if(message != null)
        Console.WriteLine(message);
}

PrintHelloSaySomething3("Matvey");
PrintHelloSaySomething3("Akakiy", "Do you like your name?");

//void PrintHelloSaySomething4(string? name = null, string? message) // нельзя. Параметры со значениями
//                                                                   // про умолчанию всегда послдение
//{
//    Console.WriteLine($"Hello, {name}");
//    if (message != null)
//        Console.WriteLine(message);
//}

float Sum(float a, float b) // функция возращает значение типа float
{
    return a + b;
}

var c = Sum(2, 4);
Console.WriteLine($"c = {c}");

float Sum2(float a, float b, float c = 0, float d = 0, float e = 0, float f = 0)
{  
    return a + b + c + d + e + f;
}

Sum2(2, 3, 4, 5, 6);
Sum2(2, 3);
Sum2(4, 5, 6);

float Sum3(float[] arr)
{
    var res = 0f;
    foreach (var a in arr)
        res += a;
    return res;
}

var arrSum = Sum3(new float[] { 1f, 2.3f, 4f, 2.4f, 5.6f, 6.63f});
Console.WriteLine($"arrSum = {arrSum}");

float Sum4(params float[] arr)
{
    var res = 0f;
    foreach (var a in arr)
        res += a;
    return res;
}

var arrSum2 = Sum4(1f, 2.3f, 4f, 2.4f, 5.6f, 6.63f);
Console.WriteLine($"arrSum = {arrSum2}");

// Пример
void WriteLineEx(string message, 
    ConsoleColor? foregroundColor = null, 
    ConsoleColor? backgroundColor = null)
{
    // делаеют одно и то же
    // если foregroundColor не null, то берется его значение, иначе значение полсе ??
    var origForegroundColor = Console.ForegroundColor;
    foregroundColor = foregroundColor ?? Console.ForegroundColor;
    // foregroundColor = foregroundColor != null ? foregroundColor : Console.ForegroundColor;
    var origBackgroundColor = Console.BackgroundColor;
    backgroundColor = backgroundColor ?? Console.BackgroundColor;

    Console.ForegroundColor = foregroundColor.Value;
    Console.BackgroundColor = backgroundColor.Value;

    Console.WriteLine(message);

    Console.ForegroundColor = origForegroundColor;
    Console.BackgroundColor = origBackgroundColor;
}

WriteLineEx(message: "Color console. Oooph",
    foregroundColor: ConsoleColor.Red,
    backgroundColor: ConsoleColor.Yellow);

WriteLineEx(message: "Color console 2. Oooph",
    foregroundColor: ConsoleColor.Cyan,
    backgroundColor: ConsoleColor.DarkBlue);

WriteLineEx(message: "New message");

void PlayWithArray(in int[] arr) // передается по ссылке, но при этом запрещено изменение
{
   //  arr = new int[] { 5, 5, 5 };
}

int[] initialArr = { 1, 2, 3, 4, 5, 6, 7, 8 };
PlayWithArray(initialArr);
foreach (var number in initialArr)
    Console.Write($"{number}, ");

int? ReadInt()
{
    var str = Console.ReadLine();
    int number;
    if (Int32.TryParse(str, out number))
        return number;

    return null;
}

Console.WriteLine("How old are you?");
var age = ReadInt();
if (age != null)
    Console.WriteLine($"Your age is {age.Value}");
else
    Console.WriteLine("I cannot convert your input into a number");

bool TryDivide(float numer, float denom, out float result)
{
    if (denom == 0f)
    {
        result = 0f;
        return false;
    }

    result = numer / denom;
    return true;
}

float result;
var divideResult = TryDivide(5f, 0f, out result);
if (divideResult)
    Console.WriteLine($"The result is {result}");
else
    Console.WriteLine($"You can not divide these numbers");

// Рекурсия - вызов функции из самой себя
int Fibonacci(int number)
{
    if (number == 0)
        return 0;

    if (number == 1)
        return 1;

    return Fibonacci(number - 1) + Fibonacci(number - 2);
}

Console.WriteLine($"{Fibonacci(20)}");

void DoSomething()
{
    void DoSomething2()
    {
        void DoSomething3()
        {

        }
    }

    DoSomething2();
}

var fRes = 2f / 3f;
Console.WriteLine($"{fRes:n2}");

void CalculateAndPrint()
{

    //string FormatFloat(float number)
    //{
    //    return $"{number:n4}";
    //}

    // короткая запись функции, return не нужен
    string FormatFloat(float number) => $"{number:n4}";

    var fRes2 = 4f / 7f;
    var fRes3 = 4f / 11f;
    var fRes4 = 23f / 37f;
    Console.WriteLine($"fRes2 = {FormatFloat(fRes2)};" +
        $"fRes3 = {FormatFloat(fRes3)};" +
        $"fRes4 = {FormatFloat(fRes4)};");
}

CalculateAndPrint();


//Gender gender = Gender.Female;
//if(gender == Gender.Male)
//{

//}

var gender = GetGender();
Console.WriteLine(gender);

if (gender == Gender.Male)
    Console.WriteLine("You are a man");
else
    Console.WriteLine("You are a woman");

//if((byte)gender == 1)
//{

//}

Gender GetGender()
{
    do
    {
        Console.WriteLine("What is your gender? " +
            "(Male / Female; male / female; m / f; M / F; 1 / 0)");
        var strGender = Console.ReadLine();

        Gender? gender = strGender switch
        {
            "Male" => Gender.Male,
            "male" => Gender.Male,
            "m" => Gender.Male,
            "M" => Gender.Male,
            "1" => Gender.Male,
            "Female" => Gender.Female,
            "female" => Gender.Female,
            "f" => Gender.Female,
            "F" => Gender.Female,
            "0" => Gender.Female,
            _ => null,
        };
        if (gender != null)
            return gender.Value;

        Console.WriteLine("Incorrect input. Please, try one more time");
    }
    while (true);
}

SetFileAccess("file.txt", MyFileAccess.Read, MyFileAccess.Read);

void SetFileAccess(string path, params MyFileAccess[] fileAccesses)
{

}

SetFileAccess2("file.txt", MyFileAccess.Read | MyFileAccess.Execute); // 0b0001 | 0b0100 = 0b0101 = 5 

void SetFileAccess2(string path, MyFileAccess fileAccess)
{
    if((fileAccess & MyFileAccess.Read) == MyFileAccess.Read) // 0b0101 & 0b0001 = 0b0001
        Console.WriteLine($"Set read for path \"{path}\"");

    if ((fileAccess & MyFileAccess.Write) == MyFileAccess.Write) // 0b0101 & 0b0010 = 0b0001
        Console.WriteLine($"Set write for path \"{path}\"");

    if ((fileAccess & MyFileAccess.Execute) == MyFileAccess.Execute) // 0b0101 & 0b0100 = 0b0100
        Console.WriteLine($"Set execute for path \"{path}\"");
}

void SetFileAccess3(string path, MyFileAccess fileAccess)
{
    if(fileAccess.HasFlag(MyFileAccess.Read))
        Console.WriteLine($"Set read for path \"{path}\"");

    if(fileAccess.HasFlag(MyFileAccess.Write))
        Console.WriteLine($"Set write for path \"{path}\"");

    if(fileAccess.HasFlag(MyFileAccess.Execute))
        Console.WriteLine($"Set execute for path \"{path}\"");
}

Console.WriteLine(MyFileAccess.Read | MyFileAccess.Execute);

Console.WriteLine("SetFileAccess3");
SetFileAccess3("file.txt", MyFileAccess.Read | MyFileAccess.Execute);

var color = MyColors.Red | MyColors.DarkCyan | MyColors.Brown;
