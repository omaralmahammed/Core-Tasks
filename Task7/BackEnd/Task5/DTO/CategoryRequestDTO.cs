namespace Day5_BackEnd.DTO
{
    public class CategoryRequestDTO
    {
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public IFormFile? CategoryImage { get; set; }
    }
}
