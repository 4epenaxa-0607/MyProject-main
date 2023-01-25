using System;

namespace Breweries.Models;
using Newtonsoft.Json;

public class breweries
{
    // public breweries(string? id, string? name, string? brewery_type, string street, string? address_2, string? address_3, string? city, string? state, 
    //     string? county_province, string? postal_code, string? country, string? longitude, string? latitude, string? phone, string? website_url, 
    //     DateTime? updated_at, DateTime? created_at){}
    
    public string? id { get; set; }
    public string? name { get; set; }
    public string? brewery_type { get; set; }
    public string? street { get; set; }
    public string? address_2 { get; set; }
    public string? address_3 { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? county_province { get; set; }
    public string? postal_code { get; set; }
    public string? country { get; set; }
    public string? longitude { get; set; }
    public string? latitude { get; set; }
    public string? phone { get; set; }
    public string? website_url { get; set; }
    public DateTime? updated_at { get; set; }
    public DateTime? created_at { get; set; }

}
