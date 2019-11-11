namespace ContactBook
{
    public class ServiceResult
    {

            public ServiceResult(int id, bool succeeded)
            {
                Id = id;
                Succeeded = succeeded;
            }

            public ServiceResult(bool succeeded)
            {
                Succeeded = succeeded;
            }

            public int Id { get; }
            public bool Succeeded { get; }

    }
}