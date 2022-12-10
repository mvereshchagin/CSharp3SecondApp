namespace CSharp3SecondApp;

[Flags] // атрибут
enum FileAccess
{
    None = 0, // 0b0000
    Read = 1, // 0b0001
    Write = 2, // 0b0010
    Execute = 4, // 0b0100
}
