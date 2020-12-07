public struct MinAndMax
{
    private int _max;
    private int _min;

    public int Min
    {
        get { return _min; }
        set { _min = value; }
    }

    public int Max
    {
        get { return _max; }
        set { _max = value; }
    }

    public bool IsBetween(int number) => (number >= _min && number <= _max);
}
