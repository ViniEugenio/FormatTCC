namespace FormatTCC.Application.Models.ViewModels
{
    public class InputResultViewModel
    {

        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public object Data { get; set; }

        public InputResultViewModel(string message, object? values = null)
        {
            Message = message;
            Data = values;
        }

        public InputResultViewModel(string message, params string[] errors)
        {
            Message = message;
            Errors.AddRange(errors);
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(List<string> errors)
        {
            Errors.AddRange(errors);
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }

    }
}
