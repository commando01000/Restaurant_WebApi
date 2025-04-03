namespace Common.Layer
{
    public class Response<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public string RedirectUrl { get; set; }
        public IEnumerable<T?> DataList { get; set; }
    }
}
