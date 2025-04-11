using System.Reflection;
using BuildingBlocks.Domain.Event;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.MassTransit;

public static class Extensions
{

    


    // Extension method để chuyển tên thành dạng underscore

}
public static class StringExtensions
{
    public static string Underscore(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    }
}