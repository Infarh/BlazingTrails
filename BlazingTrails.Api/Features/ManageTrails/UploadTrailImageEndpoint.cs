using Ardalis.ApiEndpoints;

using BlazingTrails.Api.Persistence;
using BlazingTrails.Shared.Features.ManageTrails;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BlazingTrails.Api.Features.ManageTrails;

public class UploadTrailImageEndpoint(BlazingTrailsContext Database, ILogger<UploadTrailImageEndpoint> Logger) : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<string>
{
    [HttpPost(UploadTrailImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] int TrailId, CancellationToken Cancel = default)
    {
        Logger.LogInformation("Загрузка изображение на сервер");

        var trail = await Database.Trails.SingleOrDefaultAsync(t => t.Id == TrailId, Cancel);

        if(trail is null)
        {
            Logger.LogWarning("Выполнена попытка загрузки изображения для тропы с id {TrailId}, которая отсутствует в БД", TrailId);
            return BadRequest($"Trail with id {TrailId} does not exists.");
        }

        var file = Request.Form.Files[0];
        if(file.Length == 0)
        {
            Logger.LogWarning("В переданной форме загрузки файла для тропы id {TrailId} отсутствуют данные", TrailId);
            return BadRequest("No image file.");
        }

        var file_name = $"{Guid.NewGuid()}.png";
        var save_location = Path.Combine(Directory.GetCurrentDirectory(), "Images", file_name);

        var resize_options = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new(640, 426)
        };

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(img => img.Resize(resize_options));

        await image.SaveAsPngAsync(save_location, Cancel);

        trail.Image = file_name;
        await Database.SaveChangesAsync(Cancel);

        Logger.LogInformation("Загрузка изображение на сервер выполнено успешно");
        return Ok(file_name);
    }
}
