namespace CloudDbTestSPD011.Model
{
    // сущность-пример (одна таблица)
    public class ExampleTable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // e.t.c.

        public ExampleTable()
        {
            Id = default;
            Description = "";
        }
    }
}
