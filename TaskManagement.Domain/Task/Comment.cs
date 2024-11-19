namespace TaskManagement.Domain.Task;

public class Comment
{
    public int ID { get; set; }
    public int AutherID { get; set; }
    public User.User Auther { get; set; }
    public string Text { get; set; }
    public int TaskID { get; set; }
    public Task Task { get; set; }
}


