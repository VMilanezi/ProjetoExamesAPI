namespace Exames.API.Models;

public record ResponseModel<T>(
    bool isSuccess,
    string Message,
    T? Data = default
)
{
    public static ResponseModel<T?> Ok(T? data, string message = "Operação realizada com sucesso.")
        => new(true, message, data);

    public static ResponseModel<T?> Fail(string message)
        => new(false, message, default);
}
