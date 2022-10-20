namespace BookStoreOnline.Model.Abstract
{
    public interface IContactable
    {
        string Name { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
    }
}