using System.Data;

Console.WriteLine(@"Witaj w grze Mastermind!
        Twoim zadaniem jest odgadnięcie sekwencji liczb.
        Wprowadź cztery liczby z zakresu od 1 do 10.
        Po każdej próbie komputer podsumuje twoje odpowiedzi i zwróci podpowiedź, na podstawie której możesz odgadnąć poprawne ustawienie liczb.
        2 - dobra liczba na odpowiednim miejscu
        1 - dobra liczba na złym miejscu
        0 - zła liczba");

Random random = new Random();
int[] scoreTable = { random.Next(0, 10), random.Next(0, 10), random.Next(0, 10), random.Next(0, 10) };

static int takeInGuess()
{
    int guess;
    do
    {
        try
        {
            guess = int.Parse(Console.ReadLine());
            if (guess > 9 || guess < 0)
            {
                Console.WriteLine("Proszę, wpisz liczbę od 0 do 9");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Proszę, wpisz liczbę od 0 do 9");
            guess = -1;
        }
    }
    while (guess > 9 || guess < 0);
    return guess;
}

List<int> summaryTable = new List<int>();

int roundCounter = 0;

while (!summaryTable.SequenceEqual(new List<int> { 2, 2, 2, 2 }))
{
    List<int> playerGuessTable = new List<int>();

    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine("Wpisz liczbę:");
        int guess = takeInGuess();
        playerGuessTable.Add(guess);
    }

    summaryTable.Clear(); 

    for (int i = 0; i < 4; i++)
    {
        if (playerGuessTable[i] == scoreTable[i])
        {
            summaryTable.Add(2);
        }
        else if (scoreTable.Contains(playerGuessTable[i]))
        {
            summaryTable.Add(1);
        }
        else
        {
            summaryTable.Add(0);
        }
    }

    Console.WriteLine($"Podsumowanie: {string.Join(" ", summaryTable)}\n");
    roundCounter++;
}

Console.WriteLine($"\nGratulacje! Udało ci się odgadnąć sekwencję w {roundCounter} rundach!");
