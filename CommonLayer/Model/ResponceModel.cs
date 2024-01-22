namespace CommonLayer.Model
{
    public class ResponceModel<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
