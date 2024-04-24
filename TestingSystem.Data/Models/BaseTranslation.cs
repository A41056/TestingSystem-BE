namespace TestingSystem.Data.Models
{
    public abstract class BaseTranslation<T>
    {
        public List<T> Translation { get; set; }
    }
}
