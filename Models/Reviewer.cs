namespace ReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
