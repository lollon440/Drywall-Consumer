using Discord;

namespace thing2;

public class Pet
{ 
   public string name;
   public string description;
   public string imgUrl;
   public Color color;
   public Embed embed;
   public static string[] firstNames = new string[]
   
   {
       "Toby","Lillian","Jeremy"
   };

   public static string[] titles = new string[]
   {
       ",The Happi",
       ",The consumer of drywall",
       ",Carp"
   };
   public static readonly string[] imgUrls = new string[]
   {
       "https://images.dog.ceo/breeds/hound-afghan/n02088094_1003.jpg",
       "https://images.dog.ceo/breeds/retriever-golden/n02099601_100.jpg",
       "https://images.dog.ceo/breeds/bulldog-boston/n02096585_1023.jpg",
       "https://images.dog.ceo/breeds/husky/n02110185_1469.jpg",
       "https://images.dog.ceo/breeds/shepherd-german/n02106662_1003.jpg",
       "https://images.dog.ceo/breeds/beagle/n02088364_11136.jpg",
       "https://images.dog.ceo/breeds/poodle-standard/n02113799_1002.jpg",
       "https://images.dog.ceo/breeds/rottweiler/n02106550_1002.jpg",
       "https://images.dog.ceo/breeds/boxer/n02108089_1003.jpg",
       "https://images.dog.ceo/breeds/labrador/n02099712_100.jpg",
       "https://cdn2.thecatapi.com/images/0XYvRd7oD.jpg",
       "https://cdn2.thecatapi.com/images/MTY3ODIyMQ.jpg",
       "https://cdn2.thecatapi.com/images/bpc.jpg",
   };
    public Pet()
    {
        name = firstNames[Random.Shared.Next(0, firstNames.Length)]+titles [Random.Shared.Next(0,titles.Length)];
        description = "Jenny";
        imgUrl = imgUrls[Random.Shared.Next(0, imgUrls.Length)];
        color = new Color(Random.Shared.Next(255), Random.Shared.Next(255), Random.Shared.Next(255));
        embed = new EmbedBuilder()
            .WithTitle(name)
            .WithDescription(description)
            .WithColor(color)
            .WithImageUrl(imgUrl) 
            .Build();      
    }
}