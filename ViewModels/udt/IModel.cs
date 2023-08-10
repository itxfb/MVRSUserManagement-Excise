namespace UserManagement.ViewModels.udt
{
    public interface IModel
    {
        DateTime CreatedAt { get; set; }
        long CreatedBy { get; set; }
    }
}
