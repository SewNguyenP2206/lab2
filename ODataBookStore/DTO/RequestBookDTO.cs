using ODataBookStore.Models;

namespace ODataBookStore.DTO
{
    public class RequestBookDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PressId { get; set; }
        public string PressName { get; set; }

        public Category PressCategory { get; set; }
    }
}
