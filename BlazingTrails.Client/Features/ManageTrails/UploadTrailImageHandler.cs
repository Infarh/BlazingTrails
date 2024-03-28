using BlazingTrails.Shared.Features.ManageTrails;

using MediatR;

namespace BlazingTrails.Client.Features.ManageTrails;

public class UploadTrailImageHandler(
    HttpClient Http, 
    ILogger<UploadTrailImageHandler> Logger)
    : IRequestHandler<UploadTrailImageRequest, UploadTrailImageRequest.Response>
{
    public async Task<UploadTrailImageRequest.Response> Handle(UploadTrailImageRequest request, CancellationToken Cancel)
    {
        Logger.LogInformation("Загрузка файла с изображением тропы на сервер");

        await using var file_content = request.File.OpenReadStream(request.File.Size, Cancel);

        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(file_content), "image", request.File.Name);

        var response = await Http.PostAsync(request.Route, content, Cancel);

        if (response.IsSuccessStatusCode)
        {
            var file_name = await response.Content.ReadAsStringAsync(cancellationToken: Cancel);

            Logger.LogInformation("Загрузка файла с изображением тропы на сервер выполнено успешно");
            return new(file_name);
        }
        else
        {
            Logger.LogWarning("Ошибка загрузки файла картинки тропы на сервер");
            return new("");
        }
    }
}
