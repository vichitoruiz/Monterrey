using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Infrastructure.Services;

public sealed class ApiPeruClient
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private readonly string _token;

    public ApiPeruClient(HttpClient http, string baseUrl, string token)
    {
        _http = http;
        _baseUrl = baseUrl.TrimEnd('/') + "/";
        _token = token;
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        _http.Timeout = TimeSpan.FromSeconds(5);
    }

    public async Task<(bool ok, string? nombres, string? apellidos, string? error)> ConsultarDniAsync(string dni)
    {
        try
        {
            var url = $"{_baseUrl}{dni}";
            using var resp = await _http.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
                return (false, null, null, $"HTTP {(int)resp.StatusCode}");

            var json = await resp.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // Estructura estimada (ajústala según respuesta real de apiperu.dev)
            var success = root.TryGetProperty("success", out var s) && s.GetBoolean();
            if (!success) return (false, null, null, "Respuesta no exitosa");

            var data = root.GetProperty("data");
            var nombres = data.TryGetProperty("nombres", out var n) ? n.GetString() : null;
            var apellidos = data.TryGetProperty("apellido_paterno", out var ap)
                            ? $"{ap.GetString()} {data.GetProperty("apellido_materno").GetString()}"
                            : null;

            return (true, nombres, apellidos, null);
        }
        catch (TaskCanceledException) { return (false, null, null, "Timeout API Perú"); }
        catch (Exception ex) { return (false, null, null, ex.Message); }
    }
}
