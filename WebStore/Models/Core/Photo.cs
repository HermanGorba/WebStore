namespace WebStore.Models.Core
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime UploadDate { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
