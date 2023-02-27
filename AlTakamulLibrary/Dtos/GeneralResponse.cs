namespace AlTakamulLibrary.Dtos
{
    public class GeneralResponse<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Model { get; set; }
    }
}
