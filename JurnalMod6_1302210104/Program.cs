using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Contracts;

public class SayaTubeVideo
{
    private int id;
    private string tittle;
    private int playCount;

    public SayaTubeVideo(string tittle)
    {
        Contract.Requires(tittle.Length <= 200 && tittle == null);
        this.tittle = tittle;
        Random i= new Random();
        id = i.Next(100000);
        playCount = 0;
    }

    public void IncreasePlayCount(int playCount)
    {
        Contract.Requires(playCount <= 25000000 && playCount < 0);
        this.playCount = this.playCount + playCount;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID VIDEO : " + this.id + " JUDUL VIDEO " + this.tittle + " Total Play " + this.playCount);
    }

    public int getPlayCount() {
        return this.playCount;
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string username;

    public SayaTubeUser(string username)
    {
        Contract.Requires(!string.IsNullOrEmpty(username) && username.Length <= 100);
        this.username = username;
        Random i = new Random();
        id = i.Next(100000);
        uploadedVideos= new List<SayaTubeVideo>();
    }

    
    public int GetTotalVideoPlayCount()
    {
        int totPlayCount = 0;
        for(int i = 0; i<uploadedVideos.Count; i++)
        {
            try
            {
                checked 
                {
                    totPlayCount = totPlayCount + uploadedVideos[i].getPlayCount();
                }
            }
            catch (OverflowException OverExcept)
            {
                Console.WriteLine("Angka Penjumlahan Overflow");
            }
        }
        return totPlayCount;
    }
    
    public void AddVideo(SayaTubeVideo video)
    {
        Contract.Requires(video != null && video.getPlayCount() < int.MaxValue);
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
        
        Console.WriteLine("User : " + this.username);
        for(int i = 0; i<uploadedVideos.Count; i++)
        {
            Contract.Ensures(i == 8);
            Console.Write("Video " + (i+1) + " Judul: ");
            uploadedVideos[i].PrintVideoDetails();
        }
        
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SayaTubeVideo Video1 = new SayaTubeVideo("Mallena");
        SayaTubeVideo Video2 = new SayaTubeVideo("MellisaP");
        SayaTubeVideo Video3 = new SayaTubeVideo("HIDUP DALAM KUBUR");
        SayaTubeVideo Video4 = new SayaTubeVideo("SIKSA KUBUR");
        SayaTubeVideo Video5 = new SayaTubeVideo("Panasnya Api Neraka");
        SayaTubeVideo Video6 = new SayaTubeVideo("Ingat Hidup hanya Sekali");
        SayaTubeVideo Video7 = new SayaTubeVideo("MATI PENASARAN");
        SayaTubeVideo Video8 = new SayaTubeVideo("Lumpuh Pikiran");
        SayaTubeVideo Video9 = new SayaTubeVideo("Lampas Langit");
        SayaTubeVideo Video10 = new SayaTubeVideo("Tahan");
        Video1.IncreasePlayCount(50);
        Video2.IncreasePlayCount(100);
        Video3.IncreasePlayCount(150);
        Video4.IncreasePlayCount(500);
        Video5.IncreasePlayCount(600);
        Video6.IncreasePlayCount(500);
        Video7.IncreasePlayCount(600);
        Video8.IncreasePlayCount(500);
        Video9.IncreasePlayCount(600);
        Video10.IncreasePlayCount(500);

        SayaTubeUser User1 = new SayaTubeUser("Iqnaz");
        User1.AddVideo(Video1);
        User1.AddVideo(Video2);
        User1.AddVideo(Video3);
        User1.AddVideo(Video4);
        User1.AddVideo(Video5);
        User1.AddVideo(Video6);
        User1.AddVideo(Video7);
        User1.AddVideo(Video8);
        User1.AddVideo(Video9);
        User1.AddVideo(Video10);
        Console.WriteLine(User1.GetTotalVideoPlayCount());
        User1.PrintAllVideoPlayCount();

    }
}