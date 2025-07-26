namespace LibraManage.Dtos;

public class BookDto : BaseDto
{
    public string Title { get; private set; }

    public string Summary { get; private set; }

    public string ISBN { get; private set; }
}
