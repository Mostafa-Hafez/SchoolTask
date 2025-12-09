namespace School.API.Helpers
{
    public class ResponseSchema<T>
    {
        public bool? Success { get; set; }
        public T? Data { get; set; }
        public int? Code { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public ResponseSchema()
        {
            Errors = Array.Empty<string>();
        }
    }
}
