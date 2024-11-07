namespace CasaCue.Data.Models
{
    public abstract class BaseModel
    {

    }

    public abstract class BaseModel<TKey> : BaseModel
    {
        public TKey Id { get; set; }
    }
}
