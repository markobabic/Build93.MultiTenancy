using Build93.MultiTenancy.Contracts;

namespace Build93.MultiTenancy.Example.BL.Model
{
    public class Course : ITenantEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public int? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
