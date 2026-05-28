using System.Xml.Serialization;

namespace PracticeOOP_RPG.Domain;

public static class GameStateXmlSerializer
{
    public static void Save(string filePath, GameStateDto state)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new GameDomainException("Шлях до XML-файлу не може бути порожнім.");
        if (state == null) throw new ArgumentNullException(nameof(state));

        var serializer = new XmlSerializer(typeof(GameStateDto));
        using var stream = File.Create(filePath);
        serializer.Serialize(stream, state);
    }

    public static GameStateDto Load(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new GameDomainException("Шлях до XML-файлу не може бути порожнім.");
        if (!File.Exists(filePath)) throw new FileNotFoundException("XML-файл стану гри не знайдено.", filePath);

        var serializer = new XmlSerializer(typeof(GameStateDto));
        using var stream = File.OpenRead(filePath);
        var state = serializer.Deserialize(stream) as GameStateDto;
        return state ?? throw new GameDomainException("Не вдалося десеріалізувати XML-стан гри.");
    }
}
