namespace JiangH.Interfaces
{
    public interface IRegion
    {
        Coordinate coordinate { get; }

        public string name { get; }
        string image { get; }

        ISect sect { get; set; }
    }
}
