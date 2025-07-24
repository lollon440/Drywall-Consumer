using Discord;
using Discord.Interactions;
using Microsoft.VisualBasic;

namespace thing2;

public class SlashCommandExamples : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("show-info", "Does the thing")]
    private async Task ShowInfo()
    {
        Player p = Program.GetOrCreatePlayer(Context.User.Id);
        await RespondAsync("You have a balance of " + p.balance + ",and " + p.pets.Count);
    }

    [SlashCommand("initiate-mine", "Does the thing")]
    public async Task Mine()
    {
        var buttons = new ComponentBuilder()
            .WithButton("mine", "mine-button")
            .Build();
        await RespondAsync("Get to mining! " + Context.User.Mention, components: buttons);
    }

    [ComponentInteraction("mine-button")]
    public async Task MineButton()
    {
        var buttons = new ComponentBuilder()
            .WithButton("mine", "mine-button")
            .Build();
        int increase = Random.Shared.Next(10, 20);
        Player p = Program.GetOrCreatePlayer(Context.User.Id);
        p.balance += increase;
        for(int i = 0; i>p.pets.Count; ++i)
        {
            if (p.pets[i].name.Contains ("lillian"))
            {
                increase *=  2;
            }
        }
        await DeferAsync();

        await ModifyOriginalResponseAsync(msg =>
        {
            msg.Content = "Keep mining! " + Context.User.Mention +
                          "\nYou found " + increase + ". Your new balance is: " + p.balance;
            msg.Components = buttons; // Remove the button
        });
    }

    [SlashCommand("searchforpet", "Search and optionally buy a pet")]
    public async Task SearchForPet()
    {
        Player p = Program.GetOrCreatePlayer(Context.User.Id);
        string petName = "Skippy";
        int petCost = 50;

        if (p.balance >= petCost)
        {
            p.balance -= petCost;
            Pet pet = new Pet();
            p.pets.Add(pet);
            await RespondAsync($"You bought {petName} for {petCost}! Your new balance is {p.balance}.", embed: pet.embed);
        }
        else
        {
            await RespondAsync($"You don't have enough money to buy {petName}. Your balance is {p.balance}.");
        }
        
    }
}
          
       

 
