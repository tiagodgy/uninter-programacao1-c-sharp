//Exercício 1
using System.Net.NetworkInformation;

int[] array = new int[100000];

for(int i = 0; i<array.Length; i++)
{
    array[i] = i;
}

Console.WriteLine(array[11]);


//Exercício 2
int[,] matriz = new int[100, 100];
Random rnd = new Random();
for (int i = 0; i < matriz.GetLength(0); i++)
{
    for(int j = 0; j < matriz.GetLength(1); j++)
    {
        matriz[i, j] = rnd.Next(1, 300001);
    }
}
Console.WriteLine(matriz[0, 0]);
Console.WriteLine(matriz[99,99]);

//Exercício 3
var pv = matriz[0,0];
int somatorio = 0;
for (int i = 0; i < matriz.GetLength(0); i++)
{
    for (int j = 0; j < matriz.GetLength(1); j++)
    {
        if (pv == matriz[i, j])
        {
            somatorio++;
        };
    }
}
Console.WriteLine($"Somatório: {somatorio}");
