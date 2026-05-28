using System.Text.Json;

namespace PracticeOOP_RPG.Domain;

public static class GameStateSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true
    };

    public static void Save(string filePath, GameStateDto state)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Шлях до файлу не може бути порожнім.", nameof(filePath));
        if (state == null) throw new ArgumentNullException(nameof(state));

        var json = JsonSerializer.Serialize(state, Options);
        File.WriteAllText(filePath, json);
    }

    public static GameStateDto Load(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new GameDomainException("Шлях до файлу не може бути порожнім.");
        if (!File.Exists(filePath)) throw new FileNotFoundException("Файл стану гри не знайдено.", filePath);

        var json = File.ReadAllText(filePath);
        var state = JsonSerializer.Deserialize<GameStateDto>(json, Options);
        return state ?? throw new GameDomainException("Не вдалося десеріалізувати стан гри.");
    }
}
