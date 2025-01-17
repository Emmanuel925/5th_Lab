static void ShowArray(int[] array)
{
    foreach (int x in array) Console.Write($"{x} ");
}

static int[] DeleteMax(int[] array)
{
    int max = array[0];
    int maxi = 0;
    int [] a = new int[array.Length - 1];
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
            maxi = i;
        }
    }
    for (int i = 0; i <= maxi; i++) a[i] = array[i];
    for (int i = maxi; i < array.Length - 1; i++) a[i] = array[i + 1];
    
    return a;
}

static int[] MergeArrays(int[] a, int[] b)
{
    int [] c = new int[a.Length + b.Length];
    int k = 0;
    for (int i = 0; i < a.Length; i++)
    {
        c[k] = a[i];
        k++;
    }
    for (int i = 0; i < b.Length; i++)
    {
        c[k] = b[i];
        k++;
    }

    return c;
}

Random randomizer = new Random();
int n = 7;
int[] A = new int[n];
for (int i = 0; i < n; i++) A[i] = randomizer.Next(-10, 10);

int m = 8;
int[] B = new int[m];
for (int i = 0; i < m; i++) B[i] = randomizer.Next(-10, 10);

Console.WriteLine("array A:");
ShowArray(A);

Console.WriteLine("\n\narray B:");
ShowArray(B);

A = DeleteMax(A);
B = DeleteMax(B);

Console.WriteLine("\n\nnew array A (no maximum):");
ShowArray(A);

Console.WriteLine("\n\nnew array B (no maximum):");
ShowArray(B);

A = MergeArrays(A, B);
Console.WriteLine("\n\nResult:");
ShowArray(A);
