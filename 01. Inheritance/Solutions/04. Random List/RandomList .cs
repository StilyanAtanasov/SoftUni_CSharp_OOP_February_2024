namespace CustomRandomList;
public class RandomList : List<string>
{
    public string RandomString()
    {
        int position = new Random().Next(0, Count);
        string element = base[position];
        RemoveAt(position);
        return element;
    }
}