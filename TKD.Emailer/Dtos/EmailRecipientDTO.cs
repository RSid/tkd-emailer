namespace TKD.Emailer.Models
{
    internal class EmailRecipientDTO
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }


        public EmailRecipientDTO(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
