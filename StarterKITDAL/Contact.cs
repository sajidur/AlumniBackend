namespace StarterKITDAL
{
    public class Contact:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; } 
        public string Message { get; set; }
        public int IsResponse { get; set; }
    }
}
