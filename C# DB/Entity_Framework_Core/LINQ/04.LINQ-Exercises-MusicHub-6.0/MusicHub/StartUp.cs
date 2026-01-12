namespace MusicHub;

using System;
using System.Text;
using Data;
using Initializer;
using MusicHub.Data.Models;

public class StartUp
{
    public static void Main()
    {
        using MusicHubDbContext context =
            new MusicHubDbContext();
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albums = context
            .Albums
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
            {
                a.Name,
                a.ReleaseDate,
                Producer = a.Producer!.Name,
                Songs = a.Songs
                .Select(s => new
                {
                    s.Name,
                    s.Price,
                    Writer = s.Writer.Name,
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.Writer)
                .ToArray(),
                TotalPrice = a.Price
            })
            .ToArray()
            .OrderByDescending(a => a.TotalPrice);

        StringBuilder sb = new StringBuilder();
        foreach (var a in albums) 
        {
            sb.AppendLine($"-AlbumName: {a.Name}");
            sb.AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy")}");
            sb.AppendLine($"-ProducerName: {a.Producer}");

            sb.AppendLine("-Songs:");
            int count = 1;

            foreach (var s in a.Songs) 
            {
                sb.AppendLine($"---#{count++}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Price: {s.Price:f2}");
                sb.AppendLine($"---Writer: {s.Writer}");
            }

            sb.AppendLine($"-AlbumPrice: {a.TotalPrice:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        var songs = context
            .Songs
            .Select(s => new 
            {
                
                s.Name,
                PerformersNames = s.SongPerformers
                    .Select(sp => new { 
                        sp.Performer.FirstName,
                        sp.Performer.LastName,
                    })
                    .OrderBy(sp => sp.FirstName)
                    .ThenBy(sp => sp.LastName)
                    .ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducerName =
                    s.Album != null ? (s.Album.Producer != null ? s.Album.Producer.Name : null)
                    : null,
                s.Duration
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName)
            .ToArray()
            .Where(s => s.Duration.TotalSeconds > duration)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        int count = 1;
        foreach (var s in songs) 
        {
            sb.AppendLine($"-Song #{count++}");
            sb.AppendLine($"---SongName: {s.Name}");
            sb.AppendLine($"---Writer: {s.WriterName}");

            foreach (var p in s.PerformersNames) 
            {
                sb.AppendLine($"---Performer: {p.FirstName + " " + p.LastName}");
            }

            sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
            sb.AppendLine($"---Duration: {s.Duration.ToString("c")}");
        }

        return sb.ToString().TrimEnd();
    }
}
