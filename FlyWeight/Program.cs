interface IPlayer
{
    public void AssignWeapon(string weapon);
    public void Mission();
}

class Terrorist : IPlayer
{
    private string Task;
    private string Weapon;
    public Terrorist() => Task = "Plant a bomb";

    public void AssignWeapon(string weapon) => Weapon = weapon;
    public void Mission() => Console.WriteLine($"Terrorist Weapon: {Weapon}\nTask: {Task}");
}

class CounterTerrorist : IPlayer
{
    private string Task;
    private string Weapon;
    public CounterTerrorist() => Task = "Defuse Bomb";

    public void AssignWeapon(string weapon) => Weapon = weapon;
    public void Mission() => Console.WriteLine($"Counter Terrorist Weapon: {Weapon}\nTask: {Task}");
}

class PlayerFactory
{
    private static Dictionary<string, IPlayer> GameMemory = new Dictionary<string, IPlayer>();

    public static IPlayer GetPlayer(string type)
    {
        IPlayer player = null;
        GameMemory.TryGetValue(type, out player);

        if (player == null) 
        { 
            switch (type)
            {
                case "Terrorist":
                    Console.WriteLine("Terrorist Created");
                    player = new Terrorist();
                    break;
                case "CounterTerrorist":
                    Console.WriteLine("Counter Terrorist Created");
                    player = new CounterTerrorist();
                    break;
                default:
                    Console.WriteLine("Unexpected Error");
                    break;
            }
            GameMemory.Add(type, player);
        }
        return player;
    }
}

class Program
{
    private static string[] playerType = { "Terrorist", "CounterTerrorist" };
    private static string[] weapons = { "AK-47", "Maverick", "Gut Knife", "Desert Eagle" };

    static void Main()
    {
        Random r = new Random();
        for (int i = 0; i < 10; i++)
        {
            IPlayer player = PlayerFactory.GetPlayer(playerType[r.Next(0, playerType.Length)]);
            player.AssignWeapon(weapons[r.Next(0, weapons.Length)]);
            player.Mission();
        }
    }
}