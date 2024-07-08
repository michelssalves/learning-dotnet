// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int i = 1;

int j = i++;
i = j == 42 ? 10 : 20;

Console.WriteLine(j);

Console.WriteLine(i);

Console.Write("Fill your name: ");
string name =  Console.ReadLine();
Console.WriteLine($"Hello {name}" );

Console.Write("Fill in your year of birth: ");
int year = int.Parse(Console.ReadLine());
int age = 2024 - year;

Console.WriteLine($"You have {age} year old");

if (age > 17) {
    Console.WriteLine("You are of legal age");
}else{
    Console.WriteLine("you are underage");
} 

string[] names = { "Fredy", "Mariana"};