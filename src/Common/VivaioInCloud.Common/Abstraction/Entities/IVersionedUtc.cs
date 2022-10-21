namespace VivaioInCloud.Common.Abstraction.Entities
{
    public interface IVersionedUtc
    {
        public string EntityId { get; set; }
        DateTime ValidFromtUtc { get; set; }
        DateTime ValidTotUtc { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
