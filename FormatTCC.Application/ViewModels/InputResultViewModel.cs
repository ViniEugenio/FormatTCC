namespace FormatTCC.Application.ViewModels
{
    public class InputResultViewModel
    {

        private string Message { get; set; }
        private List<string> Errors { get; set; } = new List<string>();

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(string[] errors)
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
