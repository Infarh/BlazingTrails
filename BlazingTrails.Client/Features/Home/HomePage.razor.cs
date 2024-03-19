using System.Net.Http.Json;

using Microsoft.AspNetCore.Components;

namespace BlazingTrails.Client.Features.Home;

public partial class HomePage
{
    private IEnumerable<Trail>? _Trails;

    [Inject]
    public HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _Trails = await Http.GetFromJsonAsync<IEnumerable<Trail>>("trails/trail-data.json");
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine($"Проблема с загрузкой данных: {error.Message}");
        }
    }
}
