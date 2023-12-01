namespace FormatTCC.Application.Models.ViewModels
{
    public class InputResultViewModel<T> where T : class?
    {

        public string Message { get; set; } = "Sua requisição foi processada com sucesso";
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }

        public void AddErrors(params string[] errors)
        {

            if (!errors.Any())
            {
                return;
            }

            Errors.AddRange(errors);
            Message = "Não foi possível processar sua requisição";

        }

        public void AddData(T data)
        {
            Data = data;
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }

    }
}
