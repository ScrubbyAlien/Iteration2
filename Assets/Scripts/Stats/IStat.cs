using System.Linq;
using UnityEngine;

public interface IStat
{
    public string statId { get; }
    public static T GetStatByID<T>(T[] stats, string id) where T : IStat {
        return stats.First(s => s.statId == id);
    }
}