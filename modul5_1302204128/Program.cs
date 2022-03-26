using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;

class program
{
    public static void Main(string[] argss)
    {
        SayaTubeUser user = new SayaTubeUser("Razzaq Adi Wibowo");
        SayaTubeVideo video1 = new SayaTubeVideo("Turning Red");
        SayaTubeVideo video2 = new SayaTubeVideo("Red Notice");
        SayaTubeVideo video3 = new SayaTubeVideo("Kimi No Na wa");
        SayaTubeVideo video4 = new SayaTubeVideo("Lupin");
        SayaTubeVideo video5 = new SayaTubeVideo("Moneyball");
        SayaTubeVideo video6 = new SayaTubeVideo("Love For Sale");
        SayaTubeVideo video7 = new SayaTubeVideo("Avenger: Endgame");
        SayaTubeVideo video8 = new SayaTubeVideo("Seishun Buta Yarou");
        SayaTubeVideo video9 = new SayaTubeVideo("Free Guy");
        SayaTubeVideo video10 = new SayaTubeVideo("365 Days");
        user.AddVideo(video1);
        user.AddVideo(video2);
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);
        user.PrintAllDataVideoPlaycount();
    }
}
class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideo = new List<SayaTubeVideo>();
    public string Username;

    public SayaTubeUser(string username)
    {
        Contract.Requires(username != null);
        Debug.Assert(username.Length > 0 && username.Length <= 100);
        Random r = new Random();
        id = r.Next();
        this.Username = username;
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        for (int i = 0; i < uploadedVideo.Count; i++)
        {
            total += uploadedVideo[i].PlayCount;
        }
        return total;
    }

    public void AddVideo(SayaTubeVideo vid)
    {
        uploadedVideo.Add(vid);
    }

    public void PrintAllDataVideoPlaycount()
    {
        Console.WriteLine();
        Console.WriteLine("User: " + Username);
        for (int i = 0; i < uploadedVideo.Count && i < 8; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideo[i].Title);
        }
        Console.WriteLine("Total Playcount: " + GetTotalVideoPlayCount());
    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private int playCount;
    public int PlayCount
    {
        get { return playCount; }
        set { playCount = value; }
    }
    

    public SayaTubeVideo(string title)
    {
        Contract.Requires(title != null);
        Debug.Assert(title.Length > 0 && title.Length <= 200);
        this.title = title;
        Random r = new Random();
        id = r.Next(99999);
        playCount = 0;
    }

    public void IncreasePlayCount(int playcount)
    {
        Contract.Requires(playcount > 0);
        Debug.Assert(playcount > 0 && playcount <= 25000000);
        int cek;
        try
        {
            cek = checked(playcount);
            playCount += playcount;
        }
        catch (Exception ex)
        {
            playCount = 0;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine();
        Console.WriteLine("id: " + id);
        Console.WriteLine("title: " + title);
        Console.WriteLine("playcount: " + playCount);
    }
}
