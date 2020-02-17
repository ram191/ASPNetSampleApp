namespace web_test_api.models
{
    public class Replies
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Member_id { get; set; }
        public int Topic_id { get; set; }
    }
}