namespace LibraManage.Dtos.Books;

public class BookDto : BaseDto
{
    public string Title { get; private set; }

    public string Summary { get; private set; }

    public string ISBN { get; private set; }
    public int NumberOfCopies { get; private set; }

    public int NumberOfLoanedCopies { get; private set; }
}
