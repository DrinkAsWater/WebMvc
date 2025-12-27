namespace WebMvc.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorTitle { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public string? ReturnUrl { get; internal set; }
        public string? ReturnText { get; internal set; }
        public object ErrorDetails { get; internal set; }
    }
}
