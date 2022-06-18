using System.Collections.Generic;

public static class TAG
{

}

public static class Extentions
{
    private static System.Random _rand = new System.Random();
    static public T GetRandomValue<T>(this ICollection<T> collection)
    {
        if (collection.Count == 0)
            return default(T);

        int random_index = _rand.Next(collection.Count);
        IEnumerator<T> ie = collection.GetEnumerator();
        while (random_index >= 0)
        {
            random_index--;
            ie.MoveNext();
        }

        return ie.Current;
    }
}