using ReviewApp.Models;

namespace ReviewApp.Dto
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
