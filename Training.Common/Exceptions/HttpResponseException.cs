namespace Training.Common.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int stTrainingusCode, object? value = null) =>
            (StTrainingusCode, Value) = (stTrainingusCode, value);

        public int StTrainingusCode { get; }

        public object? Value { get; }
    }
}

