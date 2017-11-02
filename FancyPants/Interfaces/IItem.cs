namespace FancyPants.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int Damage { get; set; }

        void Get();
    }
}