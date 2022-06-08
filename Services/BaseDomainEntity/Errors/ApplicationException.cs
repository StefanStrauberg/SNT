namespace BaseDomainEntity.Errors
{
    public class ApplicationException : Exception
    {
        public string Title { get; set; }
        protected ApplicationException(string title, string message) : base(message) =>
            Title = title;
    }
}