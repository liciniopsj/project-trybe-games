using System.Runtime.Intrinsics.X86;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;

namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        var filteredGames = from games in Games
                                 where games.DeveloperStudio == gameStudio.Id
                                 select games;
        return filteredGames.ToList();
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        var filteredGames = from games in Games
                            where games.Players.Contains(player.Id)
                            select games;
        return filteredGames.ToList();
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        var ownedGames = from game in Games
                         join gameId in playerEntry.GamesOwned on game.Id equals gameId
                         select game;

        return ownedGames.ToList();
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        var filteredGames = from game in Games
                            join studio in GameStudios on game.DeveloperStudio equals studio.Id
                            select new GameWithStudio
                            {
                                GameName = game.Name,
                                StudioName = studio.Name,
                                NumberOfPlayers = game.Players.Count,
                            };
        return filteredGames.ToList();
    }

    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        var filteredGames = from game in Games
                            select game.GameType;
        return filteredGames.Distinct().ToList();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        throw new NotImplementedException();
    }

}
