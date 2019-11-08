namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public Type ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public enum Type
        {
            Video = 0,
            Presentation = 1,
            Document = 2,
            Other = 3
        }
    }
}