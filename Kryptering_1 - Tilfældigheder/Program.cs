using Kryptering_1;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

#region Øvelse 1

Random rnd = new Random(250);

for (int ctr = 0; ctr < 10; ctr++)
{
    Console.WriteLine("{0,3}", rnd.Next(-10, 11));
}

var randomNumberGenerator = RandomNumberGenerator.Create();
byte[] randomBytes = new byte[32];
randomNumberGenerator.GetBytes(randomBytes);

#endregion

Console.WriteLine("----------------------");

#region Øvelse 2 - Benchmarking

Random rnd2 = new Random();

int repetitions = 1000000;
int minNumber = 0;
int maxNumber = 999;

RunBenchmark(RandomNumber);
RunBenchmark(TrueRandomNumber);

void RandomNumber()
{
    for (int i = 0; i < repetitions; i++)
    {
        rnd2.Next(minNumber, maxNumber);
    }
}

void TrueRandomNumber()
{
    for (int i = 0; i < repetitions; i++)
    {
        var randomNumberGenerator = RandomNumberGenerator.GetInt32(maxNumber);
    }
}

void RunBenchmark(Action benchmarkMethod)
{
    long startTime = DateTime.Now.Ticks;
    benchmarkMethod();
    long endTime = DateTime.Now.Ticks;
    long elapsedTime = endTime - startTime;
    Console.WriteLine($"{benchmarkMethod.Method.Name} tid (ticks): {elapsedTime}");
}

#endregion

Console.WriteLine("----------------------");

#region Øvelse 3 - Substition kryptering
Console.WriteLine("Type your message:");
string inputString = Console.ReadLine();
Encrypter encrypter = new Encrypter(8);
string encryptedString = encrypter.Encrypt(inputString);
Console.WriteLine();
Console.WriteLine("Encrypted message: " + encryptedString);
Console.WriteLine();
Console.WriteLine("Decrypted message: " + encrypter.Decrypt(encryptedString));
#endregion