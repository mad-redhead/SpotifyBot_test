using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SpotifyBot.Service.Spotify;
using Microsoft.Extensions.DependencyInjection;
using SpotifyBot.Other;

namespace SpotifyBot.Modules
{
    public class SearchCommand : ModuleBase<SocketCommandContext>
    {
        private SpotifyService spotifyService;
        public SearchCommand(IServiceProvider serviceProvider)
        {
            spotifyService = serviceProvider.GetRequiredService<SpotifyService>();
        }
        
        
        [Command("search")]
        
        [MyRatelimit(3, 30,MyMeasure.Seconds)]
        public async Task<RuntimeResult> search([Remainder] string msg)
        {
            Console.WriteLine("we in!"); 
            try 
            { 
                EmbedBuilder embedBuilerr = await spotifyService.Search(msg, Context.User);
                await Context.Channel.SendMessageAsync("", false, embedBuilerr.Build());
                return MyCommandResult.FromSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine("we messed up");
                return MyCommandResult.FromError(e.Message);
            }
        }
    }
}