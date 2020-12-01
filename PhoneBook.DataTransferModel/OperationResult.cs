namespace PhoneBook.DataTransferModel
{
    public class OperationResult<TModel> where TModel : class
    {
        public TModel Model { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
