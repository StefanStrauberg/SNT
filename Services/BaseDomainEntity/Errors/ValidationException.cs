namespace BaseDomainEntity.Errors
{
    public class ValidationException : ApplicationException
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; set; }
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base("Validation Failure", "One or more validation errors occurred")
            => ErrorsDictionary = errorsDictionary;
    }
}