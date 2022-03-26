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
        video1.IncreasePlayCount(24009500);
        user.AddVideo(video2);
        video2.IncreasePlayCount(22804000);
        user.AddVideo(video3);
        video3.IncreasePlayCount(25000000);
        user.AddVideo(video4);
        video4.IncreasePlayCount(25000000);
        user.AddVideo(video5);
        video5.IncreasePlayCount(25000000);
        user.AddVideo(video6);
        video6.IncreasePlayCount(25000000);
        user.AddVideo(video7);
        video7.IncreasePlayCount(25000000);
        user.AddVideo(video8);
        video8.IncreasePlayCount(5000000);
        user.AddVideo(video9);
        video9.IncreasePlayCount(22000000);
        user.AddVideo(video10);
        video10.IncreasePlayCount(20000000);

        //check overflow
        //for (int i = 0; i < 2000; i++)
        {
            video1.IncreasePlayCount(24009500);
        }

        user.PrintAllDataVideoPlaycount();

        Console.WriteLine();
        Console.WriteLine("------------------------- Detail Video -------------------------");

        video1.PrintVideoDetails();
        
        video2.PrintVideoDetails();
        video3.PrintVideoDetails();
        video4.PrintVideoDetails();
        video5.PrintVideoDetails();
        video6.PrintVideoDetails();
        video7.PrintVideoDetails();
        video8.PrintVideoDetails();
        video9.PrintVideoDetails();
        video10.PrintVideoDetails();
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
        int cek;
        try
        {
            for (int i = 0; i < uploadedVideo.Count; i++)
                {
                    total += uploadedVideo[i].PlayCount;
                }
            cek = checked(total);
        }
        catch (Exception e)
        {
            Console.WriteLine("Integer Overflow");
            total = 0;            
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
            cek = checked(playcount + playCount);
            playCount += playcount;
        }
        catch (Exception ex)
        {
            Console.WriteLine(title + " Integer Overflow");
            playCount = 0;
            Environment.Exit(0);
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
