static void ShowMatrix(int[,] matrix)
{
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 3} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static int FindMaxColumn(int[,] matrix)
{
    int max = matrix[0, 0];
    int max_j = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j <= i; j++)
        {
            if (matrix[i, j] > max)
            {
                max = matrix[i, j];
                max_j = j;
            }
        }
    }
    return max_j;
}

static int FindMinColumn(int[,] matrix)
{
    int min = matrix[0, 1];
    int min_j = 1;

    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
    {
        for (int j = 1 + i; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                min_j = j;
            }
        }
    }
    return min_j;
}

static int[,] DeleteColumn(int[,] matrix, int column)
{
    int [,] A = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int k = 0;
        for (int j = 0; j < column; j++)
        {
            A[i, k] = matrix[i, j];
            k++;
        }

        for (int j = column + 1; j < matrix.GetLength(1); j++)
        {
            A[i, k] = matrix[i, j];
            k++;
        }
    }
    return A;
}

int n;
do
{
    do
    {
        Console.Write($"enter matrix size (size > 1): ");
    }
    while (!int.TryParse(Console.ReadLine(), out n));
}
while (n < 2);

Random randomizer = new Random();
int[,] A = new int[n, n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        A[i, j] = randomizer.Next(-50, 50);
    }
}
ShowMatrix(A);

int max_j = FindMaxColumn(A);
int min_j = FindMinColumn(A);

if (max_j == min_j)
{
    A = DeleteColumn(A, max_j);
}
else
{
    A = DeleteColumn(A, max_j);
    A = DeleteColumn(A, min_j - 1);
}

ShowMatrix(A);
