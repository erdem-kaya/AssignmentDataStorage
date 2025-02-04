using Business.Dtos.Create;

namespace Business.Dtos.Update;

public class ContactPersonUpdateForm : ContactPersonRegistrationForm
{
    public int Id { get; set; }
}
