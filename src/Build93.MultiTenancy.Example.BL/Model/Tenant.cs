using Build93.MultiTenancy.Contracts;

namespace Build93.MultiTenancy.Example.BL.Model
{
    public class Tenant : ITenant<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public bool Active { get; set; }
    }
}
